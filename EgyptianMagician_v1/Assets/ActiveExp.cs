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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            Debug.Log("Exp add");
            _gameManager.totalExp += 3;
            Destroy(gameObject);
        }
    }
}
