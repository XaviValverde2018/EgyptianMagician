using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f;
    Vector3 forward, right;
    public Joystick joystick;
    public Rigidbody rigidbodyHorusVelocity;
    public bool isWalking;

    public Vector3 currentPos = new Vector3();
    public Vector3 oldPos = new Vector3();

    public ParticleSystem rayoSolar;
    public GameObject playerpos;


    // variables del SHOOT
    public GameObject bulletBala;
    public GameObject posicioGenerarBulletBala;
    public float elapsedTime;
    public float FireRate = 0.5f;

    // variables de find all enemies
    /*public GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    public int closestIndex = 0;
    public float closestDistance = Mathf.Infinity;
    public float tempDistance;*/

    //public float lifePlayer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        //Primer inicialitzem les dues variables currentPos i oldPos i el boleà si esta en moviment
        currentPos = playerpos.transform.position;
        oldPos = currentPos;
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
        //ClosestEnemyBullet(); DESCLICAR
        if (Input.anyKey) {
            MovePlayer();
        }
        IsPlayerInMovement();
        

    }

    void MovePlayer() {
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * joystick.Horizontal; // right or left direction. 
        Vector3 upMovemenrt = forward * moveSpeed * Time.deltaTime * joystick.Vertical; // forward or back direction.

        Vector3 heading = Vector3.Normalize(rightMovement + upMovemenrt); // total direction direction

        transform.forward = heading; // de Z axis in worldspace. Green square.
        transform.position += rightMovement; // actualposition + new position
        transform.position += upMovemenrt; // actualposition + new position

    }

    void IsPlayerInMovement() {//funcio per saber si el player s'esta movent. Si NO esta en moviment activarem el boolea. 
        currentPos = playerpos.transform.position;

        if(currentPos == oldPos) {//estem aturats
            isWalking = false;
            Debug.Log("estem quiets...");
        } else { //estem en moviment
            oldPos = currentPos;
            isWalking = true;
            Debug.Log("estem en moviment...");
        }
    }

    void ShootBullet() {
        elapsedTime += Time.deltaTime;
        if (/*(isWalking==false)&&*/elapsedTime > FireRate) {
            Instantiate(bulletBala, posicioGenerarBulletBala.transform.position, posicioGenerarBulletBala.transform.rotation);
            elapsedTime = 0f;
        }
    }
    /*void ClosestEnemyBullet() {
        for(int i =0; i<enemies.Length; i++) {
            tempDistance = Vector3.Distance(posicioGenerarBulletBala.transform.position, enemies[i].transform.position);
            if(tempDistance < closestDistance) {
                closestDistance = tempDistance;
                closestIndex = i;
            }
        }
        GameObject closestEnemy = enemies[closestIndex];
        Vector3 bulletDirection = closestEnemy.transform.position - posicioGenerarBulletBala.transform.position;
        Quaternion bulletRotation = Quaternion.LookRotation(bulletDirection, Vector3.up);
    }*/

}
