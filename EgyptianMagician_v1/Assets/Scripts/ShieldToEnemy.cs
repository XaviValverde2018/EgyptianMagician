using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldToEnemy : MonoBehaviour
{
    //This code is in bullet_Shield

    public float speed = 4f;
    Rigidbody _rbBullet;
    public Vector3 moveBulletToEnemy;
    public PyramidGenerateShells _pyramidGenerateShells;
    public bool hitEnemy;

    // Start is called before the first frame update
    void Start()
    {
        _pyramidGenerateShells = GameObject.FindObjectOfType<PyramidGenerateShells>();
        TransalteBulletToEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TransalteBulletToEnemy() {
        _rbBullet = GetComponent<Rigidbody>();
        moveBulletToEnemy = (_pyramidGenerateShells.enemyShield.transform.position - transform.position).normalized * speed;
        _rbBullet.velocity = new Vector3(moveBulletToEnemy.x, moveBulletToEnemy.y, moveBulletToEnemy.z);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Enemy")) {
            hitEnemy = true;
            Destroy(gameObject);
        } else {
            hitEnemy = false;
        }
    }
}
