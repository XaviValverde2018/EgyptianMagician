using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour {
    //This code is in button Healt Behavior
    public GameObject healthPREFAB;
    public Button healthButton;
    public bool healthActivated;
    public GameObject healtPointGenerate;
    public Transform positionJugador;
    public Animator animationHealth;
    public float timeActiveHealth;
    // Start is called before the first frame update
    void Start() {
        timeActiveHealth = 1.0f;
    }

    // Update is called once per frame
    void Update() {
        timeActiveHealth = PlayerPrefs.GetFloat("HealthBuyIncrementPP");
    }
    public void ActivarHealth() {       
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown() {
        animationHealth.SetBool("isWalk", false);
        animationHealth.SetBool("isHealth", true);
        positionJugador = healtPointGenerate.transform;
        Instantiate(healthPREFAB, positionJugador);
        healthPREFAB.transform.parent = null;

        healthButton.interactable = true;
        healthActivated = true;

        yield return new WaitForSeconds(0.1f);
        healthButton.interactable = false;
        yield return new WaitForSeconds(1.0f);
        animationHealth.SetBool("isWalk", true);
        animationHealth.SetBool("isHealth", false);
        yield return new WaitForSeconds(timeActiveHealth);   
        healthActivated = false;
        yield return new WaitForSeconds(10);
        healthButton.interactable = true;




    }
}
