using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * 10f;  //revisar aixo 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log("Name:" + other.transform.name);
        if (other.transform.CompareTag("Wall") || other.transform.CompareTag("Enemy")) {
            //Debug.Log("Name:" + other.transform.name);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Destroy(gameObject, 0.2f); descomentar recordar
        }
       
    }
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log("Name:" + collision.transform.name);
        if (collision.transform.CompareTag("Wall") || collision.transform.CompareTag("Enemy")) {
            //Debug.Log("Name:" + collision.transform.name);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Destroy(gameObject, 0.2f); descomentar recordar
        }
    }
}
