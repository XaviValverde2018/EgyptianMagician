using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisAreaAttack : MonoBehaviour
{

    public PlayerController _playerController;
    public float anubisAttack;
    public float FireRate;
    public float Elapsedtime;


    // Start is called before the first frame update
    void Start()
    {
        anubisAttack = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            Elapsedtime += Time.deltaTime;
            if(Elapsedtime > FireRate) {
                _playerController.lifePlayer -= anubisAttack;
                Debug.Log("playerplayer");
                Elapsedtime = 0;
            }

        }
    }
}
