using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class BatFollowAttack : MonoBehaviour {
    //This code is in AreaDamageEnemyToPlayer prefab (inside MummyFollow)

    [Header("Find elJugador Life")]
    public PlayerController _playerController;

    [Header("Values Attack")]
    public float elapsedTime;
    public float FireRate = 20.0f;
    public float FireRateSlow = 10.0f;
    public float resetElapsedTimeSlow;
    public float BatFollowAttackValue = 4.0f;

    [Header("Values SLOW")]
    public float randomvalue; // I LA VARIABLE --> _playerController.moveSpeed
    public int valueRandomPOISON = 10;
    public GameObject POISONImage;
    //public GameObject PoisonText;

    // Start is called before the first frame update
    void Start() {
        _playerController = FindObjectOfType<PlayerController>();
        PoisonRandomValue();
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
                // POISON ----------------------------------
                _playerController.lifePlayer -= BatFollowAttackValue;
                elapsedTime = 0f;
                if (33 < valueRandomPOISON) {
                    StartCoroutine(CountDown());
                    POISONImage.SetActive(true);
                } 
                // POISON ----------------------------------

            } else {
                Debug.Log("#error elapsedTime");
                //_playerController.moveSpeed = 4.0f;
            }
        }
    }

    void PoisonRandomValue() {
        randomvalue = Random.Range(1, 30);
    }

    IEnumerator CountDown() {
        _playerController.lifePlayer -= 1f;
        yield return new WaitForSeconds(0.5f);      
        _playerController.lifePlayer -= 1f;
        POISONImage.SetActive(false);
        randomvalue = 31;
        Debug.Log("CountDownBatPoison");
    }





}
