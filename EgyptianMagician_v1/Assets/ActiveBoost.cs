using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoost : MonoBehaviour
{
    //This code is in Time_boost button
    public EscollirBoost _escollirboost;
    public bool meteorBool;
    public bool megarayoBool;
    public bool healthBool;
    public GameObject meteorImage;
    public GameObject megarayoImage;
    public GameObject healthImage;
    // Start is called before the first frame update
    void Start()
    {
        meteorImage.SetActive(false);
        megarayoImage.SetActive(false);
        healthImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        meteorBool = _escollirboost.meteoritChoose;
        megarayoBool = _escollirboost.megarayoChoose;
        healthBool = _escollirboost.healthChoose;
        if (meteorBool) {
            MeteorBehavior();
            StartCoroutine(CountDown());

        }
        if (megarayoBool) {
            MegarayoBehavior();

        }
        if (healthBool) {
            HealthBehavior();
        }
        
    }
    public void MeteorBehavior() {
        Debug.Log("lanzando meteoritos...");
        meteorImage.SetActive(true);
        megarayoImage.SetActive(false);
        healthImage.SetActive(false);

    }
    public void MegarayoBehavior() {
        Debug.Log("Lanzando mega rayo...");
        meteorImage.SetActive(false);
        megarayoImage.SetActive(true);
        healthImage.SetActive(false);
    }
    public void HealthBehavior() {
        Debug.Log("Lanzando healt area");
        meteorImage.SetActive(false);
        megarayoImage.SetActive(false);
        healthImage.SetActive(true);

    }


}
