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
        countEnemiesFindingRoomWithTag = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesFindingRoom = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemiesFindingRoom);
        if (countEnemiesFindingRoomWithTag == 0) {
            Debug.Log("no enemy");
            SceneManager.LoadScene("gameoverwin");
        }
    }
}
