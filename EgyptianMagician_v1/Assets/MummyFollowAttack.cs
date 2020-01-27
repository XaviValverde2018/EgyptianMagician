using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyFollowAttack : MonoBehaviour
{
    //This code is in AreaDamageEnemyToPlayer prefab (inside MummyFollow)

    [Header("Find elJugador Life")]
    public PlayerController _playerController;

    [Header("Values Attack")]
    public float elapsedTime;
    public float FireRate = 3.0f;
    public float FireRateSlow = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        elapsedTime += Time.deltaTime;
        if (other.CompareTag("Player")) {
            if (elapsedTime > FireRate) {
                // SLOW ----------------------------------
                _playerController.lifePlayer--;
                elapsedTime = 0f;            
                _playerController.moveSpeed = 1.0f;
                // SLOW ----------------------------------
            } else {
                Debug.Log("#error elapsedTime");
                _playerController.moveSpeed = 4.0f;
            }
        }
    }

}
