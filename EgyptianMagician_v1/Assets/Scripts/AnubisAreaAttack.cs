﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisAreaAttack : MonoBehaviour
{

    public PlayerController _playerController;
    public float anubisAttack;
    public float FireRate;
    public float Elapsedtime;
    public GameObject _anubisLookAt;

    [Header("Animations")]
    public Animator _animatorAnubis;
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
                _anubisLookAt.transform.LookAt(_playerController.transform);
                StartCoroutine(AnubisAttacK());              
                Debug.Log("playerplayer");
                Elapsedtime = 0;
            } else {

            }

        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _animatorAnubis.SetBool("AnubisAttackBool", true);
            _animatorAnubis.SetBool("ActivarMeteoritoBool", false);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            _animatorAnubis.SetBool("AnubisAttackBool", false);
        }
    }
    /* private void OnTriggerExit(Collider other) {
         if (other.CompareTag("Player")) {
             _animatorAnubis.SetBool("AnubisAttackBool", false);
             _animatorAnubis.SetBool("AnubisIdleBool", true);
         }
     }*/
    IEnumerator AnubisAttacK() {
        _animatorAnubis.SetBool("AnubisAttackBool", true);
        _animatorAnubis.SetBool("ActivarMeteoritoBool", false);
        yield return new WaitForSeconds(0.2f);
        _playerController.lifePlayer -= anubisAttack;
        _animatorAnubis.SetBool("AnubisAttackBool", false);
    }
}
