using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //EN ESTE SCRIPT SE UNIFICARA TODA LA LOGICA PASADA LA ALPHA. 
    public GameObject[] enemiesFindingRoom;
    public int countEnemiesFindingRoomWithTag;
    public GameObject potsAnarAlSeguentNivell;


    // Start is called before the first frame update
    void Start()
    {
        countEnemiesFindingRoomWithTag = 99;
        enemiesFindingRoom = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemiesFindingRoom);
    }

    // Update is called once per frame
    void Update()
    {
        BuscarEnemicsPerPasarAlSeguentNivell();
    }



    void BuscarEnemicsPerPasarAlSeguentNivell() {
        //Debug.Log("countEnemiesFindingRoomWithTag: " + countEnemiesFindingRoomWithTag);
        countEnemiesFindingRoomWithTag = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesFindingRoom = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemiesFindingRoom);
        if (countEnemiesFindingRoomWithTag == 0) { // Activem el prefab per anar a la seguent escena. 
            Debug.Log("no enemy");
            potsAnarAlSeguentNivell.SetActive(true);
            //SceneManager.LoadScene("gameoverwin");
        } else {
            potsAnarAlSeguentNivell.SetActive(false);
        }
    }// Serveix per buscar a un array d'enemics i si es 0 activar pasar a nivell seguent. 
}
