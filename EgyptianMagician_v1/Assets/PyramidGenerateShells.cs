﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PyramidGenerateShells : MonoBehaviour
{
    //This code is in PyramidEnemy 
    [Header("EnemyList")]
    public List<GameObject> llistaEnemics = new List<GameObject>();
    public int indexRandom;
    public GameObject enemyShield;
    public GameObject child_Shell_Element;

    /*[Header("BulletValues")]
    public GameObject bulletShield;
    public GameObject posicioGenerarBulletShield;*/


    // Start is called before the first frame update
    void Start()
    {
        RandomValue();
        EscollirEnemicAmbEscut();
        

    }

    // Update is called once per frame
    void Update()
    {


    }
    void RandomValue() {
        indexRandom = Random.Range(0, llistaEnemics.Count);
    }
    void EscollirEnemicAmbEscut() {
        enemyShield = llistaEnemics[indexRandom];
        child_Shell_Element = enemyShield.transform.Find("Shell_Element").gameObject;
        child_Shell_Element.SetActive(true);
    }
   /*void ShootShield() {
     Instantiate(bulletShield, posicioGenerarBulletShield.transform.position, posicioGenerarBulletShield.transform.rotation);
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown() {
        yield return new WaitForSeconds(0.2f);
        Destroy(bulletShield);

    }*/
}
