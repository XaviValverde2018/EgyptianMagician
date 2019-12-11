using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    float currentDist = 0; // distancia actual
    float closetDist = 100f; //distancia mas larga de template. Distancia cerca 
    float TargetDist = 100f; //  distancia del sujeto mas larga de template. sujeto distancia
    int closeDistIndex = 0; // sujeto mas cerca
    int TargetIndex = -1; //  indice del enemigo
    public LayerMask layerMask;
    public List<GameObject> enemiesListInRoom = new List<GameObject>();
    public GameObject PlayerBolt;
    public Transform AttackPoint;


    public Rigidbody bullet;
    public float damage;
    public float range = 100f;

    public int enemiesleft = 0;
    bool killedAllEnemies = false;
    public ParticleSystem rayosolar;
    public GameObject gota;
    public GameObject piramid;
    public GameObject value_enemies;

    public AudioSource hitAudio;

    private void OnDrawGizmos() {
        if (getATarget) {
            for(int i = 0; i < enemiesListInRoom.Count; i++) {
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, enemiesListInRoom[i].transform.position - transform.position, out hit, 20f, layerMask);
                if(isHit&& hit.transform.CompareTag("Enemy")) {
                    //condicion de solo pintar verde el mas cerca
                    //if()
                        Gizmos.color = Color.green;
                        rayosolar.Play();
                } else {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawRay(transform.position, enemiesListInRoom[i].transform.position - transform.position);
                
            }
        }
    }

    private void Start() {
        gota.SetActive(false);
        piramid.SetActive(false);
        value_enemies.SetActive(false);
    }

    void Update() {
       
        CalculateNearestTarget(); // function to calculate de nearest target in the room.
        //if(getATarget) transform.LookAt(Vector3.forward,Vector3.zero);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesleft = enemies.Length;
        if(enemies.Length == 0) {
            Debug.Log("no hi ha enemics");
        }
    }

    void CalculateNearestTarget() {
        //Debug.Log("fora del if"+TargetDist);
        if (enemiesListInRoom.Count != 0) { // si no hay enemigos en la sala, reiniciamos variables. 
            currentDist = 0f; 
            closeDistIndex = 0; 
            TargetIndex = -1;

            for (int i = 0; i < enemiesListInRoom.Count; i++) {
                currentDist = Vector3.Distance(transform.position, enemiesListInRoom[i].transform.position);// distance: return distance between a and b. nos inventamos 35.
                //Debug.Log("currentDist" +currentDist);
                
                RaycastHit hit;
                bool isHit = Physics.Raycast(transform.position, enemiesListInRoom[i].transform.position - transform.position, out hit); //bool True if the ray intersects with a Collider, otherwise false.

                //Debug.Log("isHit" + isHit);
                if (isHit && hit.transform.CompareTag("Enemy")) {// si a impactado i el tag de quien ha impactado es Enemy

                    hitAudio.Play();
                    gota.SetActive(true);
                    piramid.SetActive(true);
                    //--------------------------------------
                    Debug.Log("le heeeeee dadoo");
                    HitTarget _hittarget = hit.transform.GetComponent<HitTarget>();
                    //Rigidbody instiantatebullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
                    //instiantatebullet.velocity = transform.TransformDirection(new Vector3(3.0f, 0, 0));
                    if(_hittarget != null) {
                        _hittarget.TakeDamage(damage);
                       
                    }




                    //-------------------------------------
                    if (TargetDist >= currentDist) { // 100 >= 35
                        TargetIndex = i; // = 1
                        TargetDist = currentDist; // 35 sera maximo cerca targetDist
                        //Debug.Log("dins del if"+TargetDist);
                    }
                }
                value_enemies.SetActive(true);
                

                if (closetDist >= currentDist) { //100>=35
                    closeDistIndex = i; // = 1
                    closetDist = currentDist; // 35 sera maximo cerca closetDist. distancia cerca. 
                }
            }
            if (TargetIndex == -1) { //reset. 
                TargetIndex = closeDistIndex;
            }
            closetDist = 100f;
            TargetDist = 100f;
            getATarget = true;
        }
        
    }


}
