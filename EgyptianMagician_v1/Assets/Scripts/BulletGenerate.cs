using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody _rbBullet;
    public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;
    public comprobacioEnemicMesAprop _target;
    public Vector3 moveBulletToEnemicMesAProp;
    //public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;
    //public GameObject enemicMesAPropBullet;
    // Start is called before the first frame update
    void Start()
    {
        TranslateBulletToEnemicMesAProp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TranslateBulletToEnemicMesAProp() {
        _rbBullet = GetComponent<Rigidbody>();
        _target = GameObject.FindObjectOfType<comprobacioEnemicMesAprop>();
        moveBulletToEnemicMesAProp = (_target.enemicMesAprop.transform.position - transform.position).normalized * speed;
        _rbBullet.velocity = new Vector3(moveBulletToEnemicMesAProp.x, moveBulletToEnemicMesAProp.y, moveBulletToEnemicMesAProp.z);
        //enemicMesAPropBullet = _comprobacioEnemicMesAprop.enemicMesAprop;
        Destroy(gameObject, 3f);

        //transform.Translate(0, 0, speed * Time.deltaTime, 0);
        //Destroy(this.gameObject, 1.5f);
    }
}
