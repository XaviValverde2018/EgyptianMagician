using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApofisArqueraLookAt : MonoBehaviour {
    //This code is in every Enemy

    [Header("Values EnemyFollow")]

    public Transform target;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
            if (playerController.PC_GM_BirdActivated == false) {
                transform.LookAt(target);
            }
        
    }
}
