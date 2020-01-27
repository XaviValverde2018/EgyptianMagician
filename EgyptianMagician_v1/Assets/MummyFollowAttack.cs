using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class MummyFollowAttack : MonoBehaviour
{
    //This code is in AreaDamageEnemyToPlayer prefab (inside MummyFollow)

    [Header("Find elJugador Life")]
    public PlayerController _playerController;

    [Header("Values Attack")]
    public float elapsedTime;
    public float FireRate = 3.0f;
    public float FireRateSlow = 10.0f;
    public float resetElapsedTimeSlow;
    public float randomvalue;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        SlowRandomValue();
        resetElapsedTimeSlow = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        elapsedTime += Time.deltaTime;
        if (other.CompareTag("Player")) {
            resetElapsedTimeSlow += Time.deltaTime;
            if (elapsedTime > FireRate) {
                // SLOW ----------------------------------
                _playerController.lifePlayer--;
                elapsedTime = 0f;
                if (randomvalue < 29) {
                   // _playerController.moveSpeed = 1.0f;
                    //contador para reiniciar
                    if(resetElapsedTimeSlow > FireRateSlow) {
                        _playerController.moveSpeed = 4.0f;
                        resetElapsedTimeSlow = 0f;
                    } else {
                        _playerController.moveSpeed = 1.0f;
                    }
                } else {
                    _playerController.moveSpeed = 4.0f;
                }
                // SLOW ----------------------------------

            } else {
                Debug.Log("#error elapsedTime");
                //_playerController.moveSpeed = 4.0f;
            }
        }
    }

    void SlowRandomValue() {
        randomvalue = Random.Range(1, 30);
    }


}
