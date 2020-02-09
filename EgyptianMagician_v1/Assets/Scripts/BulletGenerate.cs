using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
    //This code is in Prefab Bullet Player

    public float speed = 30f;
    Rigidbody _rbBullet;
    public comprobacioEnemicMesAprop _target;
    public Vector3 moveBulletToEnemicMesAProp;
    public bool hitEnemy = false;
    public PlayerController playerController;
    //public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;
    //public GameObject enemicMesAPropBullet;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        TranslateBulletToEnemicMesAProp();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyIfBulletIsntMove();
    }

    void TranslateBulletToEnemicMesAProp() {
        if (playerController.isWalking == false) {// moviment del disparat de la bullet quan estigui parat
            _rbBullet = GetComponent<Rigidbody>();
            _target = GameObject.FindObjectOfType<comprobacioEnemicMesAprop>();
            if (_target.NoEnemicsOnRoom == false) {
                moveBulletToEnemicMesAProp = (_target.enemicMesAprop.transform.position - transform.position).normalized * speed;
                _rbBullet.velocity = new Vector3(moveBulletToEnemicMesAProp.x, moveBulletToEnemicMesAProp.y, moveBulletToEnemicMesAProp.z);
            }
        } else {
            Debug.Log("we are walking"); // no moviment quan estigui moventse

        }
        
        //enemicMesAPropBullet = _comprobacioEnemicMesAprop.enemicMesAprop;
        //Destroy(gameObject, 3f);

        //transform.Translate(0, 0, speed * Time.deltaTime, 0);
        //Destroy(this.gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Enemy")){
            Debug.Log("hit!");
            hitEnemy = true; // bolea que envia a EnemyManager.cs per a dirli que l'hem tocat.
            Destroy(gameObject);
        } else {
            hitEnemy = false;
        }
    }
    void DestroyIfBulletIsntMove() {
        if(_rbBullet.velocity == new Vector3(0, 0, 0)) {
            Debug.Log("la bullet no s'esta movent");
        }
    }

}
