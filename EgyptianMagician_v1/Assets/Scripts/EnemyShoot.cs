using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //This code is in Enemy Arquero
    [Header("Enemy Shoot Status")]
    public GameObject bulletEnemy;
    public GameObject posicioGenerarBulletEnemy;
    public float elapsedTime;
    public float FireRate = 0.5f;

    [Header("Bird Activated")]
    public GameManager _gmBirdActivated;
    public bool ES_GM_BirdActivated;
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
        BirdActivated();
        if (elapsedTime > FireRate) {
            if (ES_GM_BirdActivated == false) {
                Instantiate(bulletEnemy, posicioGenerarBulletEnemy.transform.position, posicioGenerarBulletEnemy.transform.rotation);
                elapsedTime = 0f;
            } else {
                DestroyBulletsBirdActivated();
            }
        } else {
            Debug.Log("no instantiate enemy bullet");
        }

    }
    void BirdActivated() {
        ES_GM_BirdActivated = _gmBirdActivated.GM_BirdActivated;
    }
    void DestroyBulletsBirdActivated() {
        Destroy(GameObject.Find("bullet_EnemyApofis(Clone)"));
        Destroy(GameObject.Find("bullet_Enemy(Clone)"));
    }
}
