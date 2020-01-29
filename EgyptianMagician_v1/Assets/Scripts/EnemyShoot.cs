using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //This code is in Enemy Arquero
    public GameObject bulletEnemy;
    public GameObject posicioGenerarBulletEnemy;
    public float elapsedTime;
    public float FireRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();

    }
    void ShootBullet() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > FireRate) {
            Instantiate(bulletEnemy, posicioGenerarBulletEnemy.transform.position, posicioGenerarBulletEnemy.transform.rotation);
            elapsedTime = 0f;
        } else {
            Debug.Log("no instantiate enemy bullet");
        }

    }
}
