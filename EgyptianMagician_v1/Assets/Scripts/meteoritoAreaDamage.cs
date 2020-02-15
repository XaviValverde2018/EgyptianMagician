using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoritoAreaDamage : MonoBehaviour
{
    public EnemyManager _em;
    public float elapsedTime;
    public float FireRate = 20.0f;
    public int meteoritoDamage;
    public bool enemyIsInsideMeteoritoArea;
    public GameObject meteor_iconActiveDamaga;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CountDown());
    }
    private void OnTriggerStay(Collider other) {
        elapsedTime += Time.deltaTime;
        if (other.CompareTag("meteorito")) {
            if(elapsedTime > FireRate) {
                _em.vidaEnemics -= meteoritoDamage;
                elapsedTime = 0f;
                enemyIsInsideMeteoritoArea = true;
                meteor_iconActiveDamaga.SetActive(true);
            }
        }      
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("meteorito")) {
            enemyIsInsideMeteoritoArea = false;
        }
    }
    IEnumerator CountDown() {
        if (enemyIsInsideMeteoritoArea == true) {
            yield return new WaitForSeconds(1);
            meteor_iconActiveDamaga.SetActive(false);
            enemyIsInsideMeteoritoArea = false;
        }

    }
}
