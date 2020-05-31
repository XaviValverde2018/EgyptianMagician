using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveExp : MonoBehaviour
{
    //This code is in ExpEnemy prefab
    public GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 30.0f * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            Debug.Log("Exp add");        
            _gameManager.totalExp += 6;
            PlayerPrefs.SetInt("expValue",_gameManager.totalExp);
            Destroy(gameObject);
        }
    }
}
