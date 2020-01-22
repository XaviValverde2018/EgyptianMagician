using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
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
        
    }

    void TranslateBulletToEnemicMesAProp() {
        if (playerController.isWalking == false) {
            _rbBullet = GetComponent<Rigidbody>();
            _target = GameObject.FindObjectOfType<comprobacioEnemicMesAprop>();
            moveBulletToEnemicMesAProp = (_target.enemicMesAprop.transform.position - transform.position).normalized * speed;
            _rbBullet.velocity = new Vector3(moveBulletToEnemicMesAProp.x, moveBulletToEnemicMesAProp.y, moveBulletToEnemicMesAProp.z);
        } else {
            Debug.Log("we are walking");

        }
        
        //enemicMesAPropBullet = _comprobacioEnemicMesAprop.enemicMesAprop;
        //Destroy(gameObject, 3f);

        //transform.Translate(0, 0, speed * Time.deltaTime, 0);
        //Destroy(this.gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Enemy")){
            Debug.Log("hit!");
            hitEnemy = true;
            Destroy(gameObject);
        } else {
            hitEnemy = false;
        }
    }

}
