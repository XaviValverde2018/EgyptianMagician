using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargeting : MonoBehaviour
{
    //Este script sirve para hacer target del player y los enemigos para saber cuales estan mas cerca o mas lejos. 
    // Start is called before the first frame update

    public static PlayerTargeting Instance { //Singleton
        get {
            if(instance == null) {
                instance = FindObjectOfType<PlayerTargeting>();
                if(Instance == null) {
                    var instanceContainer = new GameObject("PlayerTargeting");
                    instance = instanceContainer.AddComponent<PlayerTargeting>();
                }
            }
            return instance;
        }
    }
    private static PlayerTargeting instance;
    public bool getATarget = false;
    float currentDist = 0;
    float closetDist = 100f;
    float TargetDist = 100f;
    int closeDistIndex = 0;
    int TargetIndex = -1;
    public LayerMask layerMask;
    public List<GameObject> enemiesListInRoom = new List<GameObject>();
    public GameObject PlayerBolt;
    public Transform AttackPoint;

    private void OnDrawGizmos() {
        if (getATarget) {
            for(int i = 0; i < enemiesListInRoom.Count; i++) {
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, enemiesListInRoom[i].transform.position - transform.position, out hit, 20f, layerMask);
                if(isHit&& hit.transform.CompareTag("Enemy")) {
                    Gizmos.color = Color.green;
                } else {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawRay(transform.position, enemiesListInRoom[i].transform.position - transform.position);
            }
        }
    }



    void Update() {
        if(enemiesListInRoom.Count != 0) {
            currentDist = 0f;
            closeDistIndex = 0;
            TargetIndex = -1;

            for(int i = 0; i < enemiesListInRoom.Count; i++) {
                currentDist = Vector3.Distance(transform.position, enemiesListInRoom[i].transform.position);
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, enemiesListInRoom[i].transform.position - transform.position, out hit, 20f, layerMask);

                if(isHit && hit.transform.CompareTag("Enemy")) {
                    if(TargetDist<= currentDist) {
                        TargetIndex = i;
                        TargetDist = currentDist;
                    }
                }
                if(closetDist >= currentDist) {
                    closeDistIndex = i;
                    closetDist = currentDist;
                }
            }
            if(TargetIndex == -1) {
                TargetIndex = closeDistIndex;
            }
            closetDist = 100f;
            TargetDist = 100f;
            getATarget = true;
        }
        //transform.LookAt(new Vector3(enemiesListInRoom[TargetIndex].transform.position.x, transform.position.y, transform.position.z));

    }
}
