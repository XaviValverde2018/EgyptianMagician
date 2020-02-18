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
    public Animator anim;
    public GameObject _thisRayVFX;
    //public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;
    //public GameObject enemicMesAPropBullet;
    // Start is called before the first frame update
    void Start()
    {
        _thisRayVFX = GameObject.FindGameObjectWithTag("ray");
        anim = GetComponent<Animator>();
        anim = GameObject.FindObjectOfType<Animator>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        TranslateBulletToEnemicMesAProp();
        anim.SetBool("boolrayhit", false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(KillbulletAfterFIFEseconds());
        //DestroyIfBulletIsntMove();
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
            StartCoroutine(CountDown());
        } else {
            hitEnemy = false;
        }
        if (other.transform.CompareTag("Wall")) {
            Debug.Log("wallet");
            anim.SetBool("boolrayhit", true);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Enemy")) {
            StartCoroutine(ExitCountDown());
        }
    }
    void DestroyIfBulletIsntMove() {
        if(_rbBullet.velocity == new Vector3(0, 0, 0)) {
            Debug.Log("la bullet no s'esta movent");
        }
    }
    IEnumerator CountDown() {
        _rbBullet.velocity = new Vector3(0, 0, 0);
        _thisRayVFX.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("boolrayhit", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator ExitCountDown() {
        anim.SetBool("boolrayhit", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator KillbulletAfterFIFEseconds() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
