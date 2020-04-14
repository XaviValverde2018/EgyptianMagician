using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmitForBeta : MonoBehaviour
{
    public PlayerController _pc;
    public GameObject POISON;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(Posion());
        }
    }
    IEnumerator Posion() {
        POISON.SetActive(true);
        _pc.moveSpeed = 0.04f;
        yield return new WaitForSeconds(1.8f);
        POISON.SetActive(false);
        _pc.moveSpeed = 13;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
