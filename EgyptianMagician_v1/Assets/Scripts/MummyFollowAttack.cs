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
    public Animator AttackMummyFollow;
    public bool attack;
    public EnemyManager _em;

    [Header("Values SLOW")]
    public float randomvalue; // I LA VARIABLE --> _playerController.moveSpeed
    public int valueRandomSLOW = 10;
    public GameObject SLOWImage;
    public Button birdButtonSTUN;

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
        if (attack) {
            AttackMummyFollow.SetBool("isAttack", true);
        } else {
            AttackMummyFollow.SetBool("isAttack", false);
        }
        if(_em.vidaEnemics <= 0) {
            this.transform.parent = null;
            AttackMummyFollow = null;
            _em = null;
            StartCoroutine(CountDownDie());

        }
    }
    private void OnTriggerStay(Collider other) {
        elapsedTime += Time.deltaTime;
        if (other.CompareTag("Player")) {
            attack = true;
            resetElapsedTimeSlow += Time.deltaTime;
            if (elapsedTime > FireRate) {
                // SLOW ----------------------------------
                _playerController.lifePlayer -= MummyFollowAttackValue;
                
                elapsedTime = 0f;
                if (randomvalue < valueRandomSLOW) {
                    StartCoroutine(CountDown());
                    _playerController.moveSpeed = 1.0f;
                    SLOWImage.SetActive(true);
                    birdButtonSTUN.interactable = false;
                }
                // SLOW ----------------------------------

            } else {
                Debug.Log("#error elapsedTime");
                //_playerController.moveSpeed = 4.0f;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            attack = false;
            
        }
    }

    void SlowRandomValue() {
        randomvalue = Random.Range(1, 30);
    }

    IEnumerator CountDown() {
        yield return new WaitForSeconds(1);
        SLOWImage.SetActive(false);
        birdButtonSTUN.interactable = true;
        _playerController.moveSpeed = 10.0f;
        randomvalue = 31;
        Debug.Log("CountDown");
        }
    IEnumerator CountDownDie() {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    



}
