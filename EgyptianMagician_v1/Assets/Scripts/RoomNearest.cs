using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNearest : MonoBehaviour
{
    //Este codigo sirve para tener una area donde poder hacer nearest con los enemigos. 
    List<GameObject> enemiesListInRoom = new List<GameObject>();
    public bool playerInThisRoom = false;
    public bool isClearRoom = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInThisRoom) {
            //Debug.Log("quants enemics" + enemiesListInRoom.Count);

            if (enemiesListInRoom.Count <= 0 && !isClearRoom) {
                isClearRoom = true;
                //Debug.Log("clear room from enemies");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            playerInThisRoom = true;
            PlayerTargeting.Instance.enemiesListInRoom = new List<GameObject>(enemiesListInRoom);//revisarooooooooooo
            Debug.Log("Enemy count:" + PlayerTargeting.Instance.enemiesListInRoom.Count);
            //Debug.Log("Player Enter in the room!");
        }
        if (other.CompareTag("Enemy")) {
            enemiesListInRoom.Add(other.gameObject);
            //Debug.Log("Enemy name:" + other.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            playerInThisRoom = false;
        }
        if (other.CompareTag("Enemy")) {
            enemiesListInRoom.Remove(other.gameObject);
        }
    }

}
