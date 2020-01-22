using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamageEnemyTrigger : MonoBehaviour
{
    public PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("EnemyDamageToPlayer")) {
            _playerController.lifePlayer -= 1*Time.deltaTime;
        }
    }
}
