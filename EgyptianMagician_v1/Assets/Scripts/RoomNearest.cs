using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNearest : MonoBehaviour
{
    //Este codigo sirve para tener una area donde poder hacer nearest con los enemigos. 
    List<GameObject> enemiesListInRoom = new List<GameObject>();
    public bool playerInThisRoom = false;
    public bool isClearRoom;
    public PlayerController _playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        isClearRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInThisRoom) {
            //Debug.Log("quants enemics" + enemiesListInRoom.Count);

            if (enemiesListInRoom.Count <= 0 && !isClearRoom) {
                isClearRoom = true;
                //Debug.Log("clear room from enemies");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            playerInThisRoom = true;
            PlayerTargeting.Instance.enemiesListInRoom = new List<GameObject>(enemiesListInRoom);//revisarooooooooooo
            Debug.Log("Enemy count:" + PlayerTargeting.Instance.enemiesListInRoom.Count);
        }
        if (other.CompareTag("Enemy")) {
            enemiesListInRoom.Add(other.gameObject);
            //Debug.Log("Enemy name:" + other.gameObject.name);
        }

    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            playerInThisRoom = false;
        }
        if (other.CompareTag("Enemy")) {
            enemiesListInRoom.Remove(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other) {
        if (_playercontroller.currentPos == _playercontroller.oldPos) {
            for (int i = 0; i < PlayerTargeting.Instance.enemiesListInRoom.Count; i++) {
                _playercontroller.transform.LookAt(PlayerTargeting.Instance.enemiesListInRoom[i].transform);
                _playercontroller.rayoSolar.Play();
                Debug.Log("estic PARAT");

                //Debug.Log("Player Enter in the room!");
            }
        } else {
            _playercontroller.rayoSolar.Stop();
            _playercontroller.transform.LookAt(null);
            Debug.Log("estic MOVENTME");
        }
    }

}
