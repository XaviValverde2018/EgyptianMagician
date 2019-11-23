using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f;
    Vector3 forward, right;


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
        
    }

    void MovePlayer() {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"); // positive o negative direction. 
        Vector3 upMovemenrt = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"); // up and down direction.

        Vector3 heading = Vector3.Normalize(rightMovement + upMovemenrt); // total direction

        transform.forward = heading; // de Z axis in worldspace. Green square.
        transform.position += rightMovement; // actualposition + new position
        transform.position += upMovemenrt; // actualposition + new position
    }
}
