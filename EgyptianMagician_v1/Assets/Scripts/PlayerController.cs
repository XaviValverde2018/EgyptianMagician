using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    // This code is in elJugador

    [SerializeField]
    public Joystick joystick;
    Vector3 forward, right;

    [Header("Status")]
    public float moveSpeed = 4f;
    public float lifePlayer;

    [Header("Movement")]
    public Rigidbody rigidbodyHorusVelocity;
    public bool isWalking;
    public Vector3 currentPos = new Vector3();
    public Vector3 oldPos = new Vector3();
    public GameObject playerpos;
    public float playerHeight = 0.98f;

    [Header("Particles")]
    public ParticleSystem rayoSolar;

    // variables del SHOOT
    [Header("Shoot")]
    public GameObject bulletBala;
    public GameObject posicioGenerarBulletBala;
    public float elapsedTime;
    public float FireRate = 0.5f;

    [Header("Bird Activated")]
    public GameManager _gmActiveBird;
    public bool PC_GM_BirdActivated;
    public float moveBirdSpeed = 20f;
    public float birdHeight = 2.5f;
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
        // logica per activar el modo BIRD
        PC_GM_BirdActivated = _gmActiveBird.GM_BirdActivated;
        if (PC_GM_BirdActivated) {
            Debug.Log("PC_GM_BirdActivated :"+PC_GM_BirdActivated);
            BirdMovement();
        } else {// logica normal, sense el modo BIRD
            ShootBullet();
            //ClosestEnemyBullet(); DESCLICAR
            if (Input.anyKey) {
                MovePlayer();
            }
            IsPlayerInMovement();
        }


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
        this.transform.position = new Vector3(transform.position.x, playerHeight, transform.position.z);

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
        if ((isWalking==false)&&elapsedTime > FireRate) {// disparar quan estigui quiet
            Instantiate(bulletBala, posicioGenerarBulletBala.transform.position, posicioGenerarBulletBala.transform.rotation);
            elapsedTime = 0f;
        } else {
            Debug.Log("no instantiate"); // no disparar quan estigui moventse. 
        }
    }
    void BirdMovement() {// función ocn la lógica de hacer daño al player
        Vector3 direction = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 rightMovement = right * moveBirdSpeed * Time.deltaTime * joystick.Horizontal; // right or left direction. 
        Vector3 upMovemenrt = forward * moveBirdSpeed * Time.deltaTime * joystick.Vertical; // forward or back direction.

        Vector3 heading = Vector3.Normalize(rightMovement + upMovemenrt); // total direction direction

        transform.forward = heading; // de Z axis in worldspace. Green square.
        transform.position += rightMovement; // actualposition + new position
        transform.position += upMovemenrt; // actualposition + new position
        this.transform.position = new Vector3(transform.position.x, birdHeight, transform.position.z);
    }



}
