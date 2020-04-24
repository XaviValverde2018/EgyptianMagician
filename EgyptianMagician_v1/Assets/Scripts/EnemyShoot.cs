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
    public GameObject _playerTarget;
    public AudioSource audioShootBullet;

    [Header("Bird Activated")]
    public GameManager _gmBirdActivated;
    public bool ES_GM_BirdActivated;

    [Header("Line Renderer")]
    public LineRenderer lineRenderer;


    private void OnDrawGizmos() {
        RaycastHit hit;
        bool isHit = Physics.Raycast(posicioGenerarBulletEnemy.transform.position, _playerTarget.transform.position - posicioGenerarBulletEnemy.transform.position, out hit);
        Gizmos.color = Color.red;
        Debug.DrawRay(posicioGenerarBulletEnemy.transform.position, _playerTarget.transform.position - posicioGenerarBulletEnemy.transform.position, Color.red);
    }

    // Start is called before the first frame update
    void Start()
    {
       lineRenderer.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
        DrawLineRenderer();

    }
    void ShootBullet() {
        elapsedTime += Time.deltaTime;
        BirdActivated();
        if (elapsedTime > FireRate) {
            if (ES_GM_BirdActivated == false) {
                StartCoroutine(DrawLineRenderer());
                Instantiate(bulletEnemy, posicioGenerarBulletEnemy.transform.position, posicioGenerarBulletEnemy.transform.rotation);
                if (!audioShootBullet.isPlaying) { audioShootBullet.Play(); }
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
    IEnumerator DrawLineRenderer() {
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, posicioGenerarBulletEnemy.transform.position);
        lineRenderer.SetPosition(1, _playerTarget.transform.position);
        yield return new WaitForSeconds(0.4f);
        lineRenderer.enabled = false;
    }
}
