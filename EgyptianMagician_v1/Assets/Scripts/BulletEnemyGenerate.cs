using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyGenerate : MonoBehaviour
{
    //This code is inBulletEnemy prefab
    [Header("Enemy Bullet Status")]
    public float speed = 10f;
    Rigidbody _rbBulletEnemy;
    public comprobacioEnemicMesAprop _playerTarget;
    public PlayerController _playerController;
    public bool hitPlayer = false;
    public Vector3 moveBulletToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootToPlayer();

    }
    void ShootToPlayer() {
        //Aqui hauriem de comprovar que existeix el player
        _playerTarget = GameObject.FindObjectOfType<comprobacioEnemicMesAprop>();
        _rbBulletEnemy = GetComponent<Rigidbody>();
        //_rbBulletEnemy.velocity = new Vector3(1, 0, 0).normalized*speed;
        moveBulletToPlayer = (_playerTarget.transform.position - transform.position).normalized * speed;
        _rbBulletEnemy.velocity = new Vector3(moveBulletToPlayer.x, moveBulletToPlayer.y, moveBulletToPlayer.z);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            Debug.Log("Hit a Player!");
            hitPlayer = true;
            DamagePlayer();
            Destroy(gameObject);
        } else {
            hitPlayer = false;
        }
    }
    void DamagePlayer() {
        _playerController.lifePlayer--;
    }

}
