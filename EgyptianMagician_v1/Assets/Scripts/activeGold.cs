using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeGold : MonoBehaviour
{
    //This code is in GoldEnemy
    public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;
    Rigidbody _rbGoldEnemy;
    public Vector3 moveGoldEnemyToPlayer;
    public float speed = 10f;
    public bool goldHitsPlayer;
    public GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CountDown());
    }
    void MoveGoldToPlayer() {
        _comprobacioEnemicMesAprop = GameObject.FindObjectOfType<comprobacioEnemicMesAprop>();
        _rbGoldEnemy = GetComponent<Rigidbody>();
        moveGoldEnemyToPlayer = (_comprobacioEnemicMesAprop.transform.position - transform.position).normalized * speed;
        _rbGoldEnemy.velocity = new Vector3(moveGoldEnemyToPlayer.x, moveGoldEnemyToPlayer.y, moveGoldEnemyToPlayer.z);
        _rbGoldEnemy.velocity += _rbGoldEnemy.velocity.normalized * 10;

    }
    IEnumerator CountDown() {
        yield return new WaitForSeconds(3);
        MoveGoldToPlayer();
        Debug.Log("CountDown");
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            Debug.Log("Gold hits Player");
            goldHitsPlayer = true;
            _gameManager.totalGold++;
            Destroy(gameObject);
        } else {
            goldHitsPlayer = false;
        }
    }

}
