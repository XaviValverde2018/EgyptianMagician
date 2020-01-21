using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour
{
    public float speed = 100f;
    //public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;
    //public GameObject enemicMesAPropBullet;
    // Start is called before the first frame update
    void Start()
    {
        //enemicMesAPropBullet = _comprobacioEnemicMesAprop.enemicMesAprop;
    }

    // Update is called once per frame
    void Update()
    {
        TranslateBulletToEnemicMesAProp();
    }

    void TranslateBulletToEnemicMesAProp() {
        transform.Translate(0, 0, speed * Time.deltaTime, 0);
        Destroy(this.gameObject, 1.5f);
    }
}
