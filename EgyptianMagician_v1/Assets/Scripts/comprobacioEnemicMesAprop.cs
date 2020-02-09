﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comprobacioEnemicMesAprop : MonoBehaviour
{
    // This code is in elJugador
    [Header("List Enemys room")]
    public List<GameObject> llistaEnemics = new List<GameObject>();
    [Header("Distance Enemy Values")]
    public float distanciaEntrePlayerIEnemicActual;
    public float distanciaMesAprop;
    public GameObject enemicMesAprop;
    public int indexEnemicMesAprop;
    public GameObject GOenemicMesaprop;
    [Header("Remove Enemy death List")]
    public int vidaEnemicComprobacio = 99;//variables per a borrar, son per TEST
    public GameObject enemicTemplateMesLLuny;

    private void OnDrawGizmos() {
        for(int i=0; i< llistaEnemics.Count; i++) {
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, llistaEnemics[i].transform.position - transform.position, out hit);
            if (isHit && hit.transform.CompareTag("Enemy")) {
                Gizmos.color = Color.blue;
            } else {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawRay(transform.position, llistaEnemics[i].transform.position - transform.position);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        distanciaMesAprop = 999.0f;
        //vidaEnemicComprobacio = GameObject.Find("lilaEnemic20").GetComponent<EnemyManager>().vidaEnemics;
    }

    // Update is called once per frame
    void Update()
    {

        GOenemicMesaprop = CalculAprop();
        //vidaEnemicComprobacio = GameObject.Find("lilaEnemic20").GetComponent<EnemyManager>().vidaEnemics;
        Debug.Log("ENEMICMESAPROP: " + GOenemicMesaprop.name);
        vidaEnemicComprobacio = GameObject.Find(GOenemicMesaprop.name).GetComponent<EnemyManager>().vidaEnemics;
        // ERROR AMB TOT AIXO? QUE S'EXECUTA UN COP I HEM DE FER QUE S'EXECUTI CONTINUAMENT *************
        //Debug.Log("VIDAENEMICCOMPROBACIO: " + vidaEnemicComprobacio);
        if (Input.GetKeyDown(KeyCode.A)) {
            llistaEnemics.Remove(llistaEnemics[indexEnemicMesAprop]);
            Destroy(enemicMesAprop);
            enemicMesAprop = enemicTemplateMesLLuny;
            distanciaMesAprop = 999.0f;

        }
        //TreureEnemicMortDeLaLlista();
    }
    GameObject CalculAprop() {

        if (llistaEnemics.Count != 0) {

            for (int i = 0; i < llistaEnemics.Count; i++) {// en aquest bucle busquem l'enemic de mes aprop.
                distanciaEntrePlayerIEnemicActual = Vector3.Distance(transform.position, llistaEnemics[i].transform.position);
                if (distanciaEntrePlayerIEnemicActual < distanciaMesAprop) {
                    distanciaMesAprop = distanciaEntrePlayerIEnemicActual;
                }
            }
            for (int i = 0; i < llistaEnemics.Count; i++) {// En aquest bucle tenim el enemic mes aprop. 
                if (distanciaMesAprop == Vector3.Distance(transform.position, llistaEnemics[i].transform.position)) {
                    // MODIFICAR EL LOOKAT perque nomes s'activi quan BIRDACTIVATED = FALSE
                    transform.LookAt(llistaEnemics[i].transform);
                    Debug.Log("l'enemic mes aprop es: " + llistaEnemics[i].name);
                    enemicMesAprop = llistaEnemics[i];
                    indexEnemicMesAprop = i;
                    /*-------Lógica de la qual afecta l'enemic més aprop -------*/
                    //vidaEnemicComprobacio = GameObject.Find("enemicMesAprop").GetComponent<EnemyManager>().vidaEnemics;
                    //Debug.Log("vidaEnemicComprobacio: "+vidaEnemicComprobacio);
                    /*-------FIN: Lógica de la qual afecta l'enemic més aprop -------*/

                }
            }
            //Debug.Log(distanciaMesAprop);
            //aqui fem el remove de la llista. 
        } else {
            Debug.Log("no queden enemics");
        }
        return enemicMesAprop.gameObject;
    }
    /*void TreureEnemicMortDeLaLlista() {
        //Debug.Log("Vida En Directe EMA:"+vidaEnemicComprobacio);
        if (vidaEnemicComprobacio <=0/*posarcodidequannoliquedavidal'enemic) {
            for(int i=0; i < llistaEnemics.Count; i++) {
                llistaEnemics.Remove(llistaEnemics[2]);
                //Debug.Log(llistaEnemics[indexEnemicMesAprop].name);
            }
        }
    }*/

}
