using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class MummyFollowAttack : MonoBehaviour
{
    //This code is in AreaDamageEnemyToPlayer prefab (inside MummyFollow)

    [Header("Find elJugador Life")]
    public PlayerController _playerController;

    [Header("Values Attack")]
    public float elapsedTime;
    public float FireRate = 20.0f;
    public float FireRateSlow = 10.0f;
    public float resetElapsedTimeSlow;
    public float MummyFollowAttackValue = 4.0f;

    [Header("Values SLOW")]
    public float randomvalue; // I LA VARIABLE --> _playerController.moveSpeed
    public int valueRandomSLOW = 10;
    public GameObject slowText;

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
                _playerController.lifePlayer -= MummyFollowAttackValue;
                elapsedTime = 0f;
                if (randomvalue < valueRandomSLOW) {
                    StartCoroutine(CountDown());
                    _playerController.moveSpeed = 1.0f;
                    slowText.SetActive(true);
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

    IEnumerator CountDown() {
        yield return new WaitForSeconds(3);
        _playerController.moveSpeed = 4.0f;
        randomvalue = 31;
        Debug.Log("CountDown");
        }

    



}
