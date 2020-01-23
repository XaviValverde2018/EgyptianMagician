using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // This code is every Enemy

    //public GameObject value_enemy1;
    //public GameObject enemy1;
    [Header("Enemy Status")]
    public int vidaEnemics;
    // Start is called before the first frame update
    void Start()
    {

        //value_enemy1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //value_enemy1.transform.position = enemy1.transform.position;
        //value_enemy1.SetActive(true);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("bullet")) {
            DamagePlayerToEnemy();
            if(vidaEnemics <= 0) {
                
            }
        }
    }
    void DamagePlayerToEnemy() {
        vidaEnemics--;
    }

}
