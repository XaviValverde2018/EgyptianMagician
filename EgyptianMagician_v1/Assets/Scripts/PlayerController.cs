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
    //public float lifePlayer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey) {
            MovePlayer();
        }
        ConditionNotWalking();
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

        if (joystick.Horizontal == 0 && joystick.Vertical == 0) {
            for (int i = 0; i < PlayerTargeting.Instance.enemiesListInRoom.Count; i++) {
                transform.LookAt(PlayerTargeting.Instance.enemiesListInRoom[i].transform);
                //Debug.Log("Player Enter in the room!");
            }
        }
    }
    void ConditionNotWalking() {
        if (joystick.Horizontal == 0 && joystick.Vertical == 0) { //en teoria amn el OnPointerUp() funcionaria.
            Debug.Log(joystick.Horizontal);// value -1 to 1 
            Debug.Log(joystick.Vertical);// value -1 to 1 
            Ssphere.SetActive(true);
        } else {
            Ssphere.SetActive(false);
        }
    }
}
