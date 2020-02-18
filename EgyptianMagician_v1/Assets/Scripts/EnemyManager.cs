using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    // This code is every Enemy

    //public GameObject value_enemy1;
    //public GameObject enemy1;
    [Header("Enemy Status")]
    public int vidaEnemics;
    public bool enemicMort;

    [Header("Shield Status")]
    public bool ShieldActive;
    public PyramidGenerateShells _pyramidGenerateShells;
    public int lifeShield = 500;
    public int vidaEnemicActual;

    // Start is called before the first frame update
    void Start()
    {

        // FUNCIONS DEL SHIELD PER A DESENVOLUPAR
        //vidaEnemicActual = _pyramidGenerateShells.lifeEnemyShield;
        //vidaEnemicActual += lifeShield;
        //vidaEnemics += vidaEnemicActual;

    }

    // Update is called once per frame

    void Update()
    {

        //Debug.Log("vidaEnemics: " + vidaEnemics);
        //value_enemy1.transform.position = enemy1.transform.position;
        //value_enemy1.SetActive(true);
    }
    private void OnTriggerEnter(Collider other) {

        if (other.transform.CompareTag("bullet")) {
            DamagePlayerToEnemy();
            if(vidaEnemics <= 0) {
                enemicMort = true;

            } else {
                enemicMort = false;
            }
        }
    }
    void DamagePlayerToEnemy() {
        vidaEnemics--;

    }

    
   

}
