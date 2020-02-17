using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class AmmitAttack : MonoBehaviour 
{
    //This code is in AreaDamageEnemyToPlayerSTUN prefab (inside Ammit)

    [Header("Find elJugador Life")]
    public PlayerController _playerController;

    [Header("Values Attack")]
    public float elapsedTime;
    public float FireRate = 100.0f; 
    public float FireRateSlow = 10.0f;
    public float resetElapsedTimeSlow;
    public float AmmitAttackValue = 10.0f;

    [Header("Values STUN")]
    public float randomvalue; // I LA VARIABLE --> _playerController.moveSpeed
    public int valueRandomSTUN = 10;
   // public GameObject stunText;
    public GameObject STUNimage;
    public Button birdButtonSTUN;

    // Start is called before the first frame update
    void Start() {
        _playerController = FindObjectOfType<PlayerController>();
        SlowRandomValue();
        resetElapsedTimeSlow = 0f;
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerStay(Collider other) {
        elapsedTime += Time.deltaTime;
        if (other.CompareTag("Player")) {
            resetElapsedTimeSlow += Time.deltaTime;
            if (elapsedTime > FireRate) {
                // STUN ----------------------------------
                _playerController.lifePlayer -= AmmitAttackValue;
                Debug.Log("Ammit Attack -10");
               // _playerController.lifePlayer -= 10 * Time.deltaTime;
                elapsedTime = 0f;
            
            }
            if (randomvalue < valueRandomSTUN) {
                Debug.Log("StartCorutine, value moveSpeedPlayer:" + _playerController.moveSpeed);
                StartCoroutine(CountDown());
                _playerController.moveSpeed = 0.0001f;
                //stunText.SetActive(true);
                STUNimage.SetActive(true);
                birdButtonSTUN.interactable = false;

            } else {
                STUNimage.SetActive(false);
            }
            // STUN --------------------------------------
        }
    }

    void SlowRandomValue() {
        randomvalue = Random.Range(1, 30);
    }

    IEnumerator CountDown() {
        yield return new WaitForSeconds(2);
        STUNimage.SetActive(false);
        birdButtonSTUN.interactable = true;
        _playerController.moveSpeed = 10.0f;
        randomvalue = 31;
        Debug.Log("EndCorutine, value moveSpeedPlayer:" + _playerController.moveSpeed);
    }





}
