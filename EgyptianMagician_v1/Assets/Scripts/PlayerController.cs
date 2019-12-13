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
    public GameObject Ssphere;
    public Rigidbody rigidbodyHorusVelocity;
    public bool isWalking;
    [SerializeField]
    public Vector3 isWalkVector = new Vector3(0, 0, 0);

    public Vector3 currentPos = new Vector3();
    public Vector3 oldPos = new Vector3(0, 0, 0);
    public ParticleSystem rayoSolar;
    public GameObject playerpos;
    //public float lifePlayer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = playerpos.transform.position;
        //oldPos = currentPos;
        if (currentPos == oldPos) {
            //Debug.Log("estic ATURAT");
        } else {
            //Debug.Log("estic MOVENTME");
        }
        oldPos = currentPos;
        if(Input.anyKey) {
            MovePlayer();
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

  
    }

}
