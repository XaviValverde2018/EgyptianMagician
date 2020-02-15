using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour {
    //This code is in button Healt Behavior
    public GameObject healthPREFAB;
    public Button healthButton;
    public bool healthActivated;
    public PlayerController _targetPlayer;
    public Transform positionJugador;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void ActivarHealth() {       
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown() {
        positionJugador = _targetPlayer.transform;
        Instantiate(healthPREFAB, positionJugador);
        healthPREFAB.transform.parent = null;

        healthButton.interactable = true;
        healthActivated = true;
        yield return new WaitForSeconds(0.1f);

        healthButton.interactable = false;
        yield return new WaitForSeconds(5);   
        healthActivated = false;
        yield return new WaitForSeconds(10);
        healthButton.interactable = true;




    }
}
