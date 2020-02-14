using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour {

    public GameObject healthPREFAB;
    public Button healthButton;
    public bool healthActivated;
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
            healthButton.interactable = true;
            yield return new WaitForSeconds(0.1f);
            healthButton.interactable = false;
            healthPREFAB.SetActive(true);
            yield return new WaitForSeconds(7);
            healthPREFAB.SetActive(false);
            yield return new WaitForSeconds(10);
            healthButton.interactable = true;

    }
}
