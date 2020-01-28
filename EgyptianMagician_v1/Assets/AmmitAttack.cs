﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class AmmitAttack : MonoBehaviour 
{
    //This code is in AreaDamageEnemyToPlayerSTUN prefab (inside Ammit)

    [Header("Find elJugador Life")]
    public PlayerController _playerController;

    [Header("Values Attack")]
    public float elapsedTime;
    public float FireRate = 100.0f; // LA VARIABLE PER AMPLIAR L'ATAC DE l'AMMIT.
    public float FireRateSlow = 10.0f;
    public float resetElapsedTimeSlow;

    [Header("Values SLOW")]
    public float randomvalue; // I LA VARIABLE --> _playerController.moveSpeed

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
                _playerController.lifePlayer -= 10;
               // _playerController.lifePlayer -= 10 * Time.deltaTime;
                elapsedTime = 0f;
                /*if (randomvalue < 29) {
                    StartCoroutine(CountDown());
                    _playerController.moveSpeed = 0.0001f;
                }*/
                // STUN ----------------------------------
            }
        }
    }

    void SlowRandomValue() {
        randomvalue = Random.Range(1, 30);
    }

    IEnumerator CountDown() {
        yield return new WaitForSeconds(6);
        _playerController.moveSpeed = 4.0f;
        randomvalue = 31;
        Debug.Log("CountDown");
    }





}
