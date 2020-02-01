using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EscollirBoost : MonoBehaviour
{
    //This code is in ChooseButtonCanvas 
    public Button[] boostList;
    public bool meteoritChoose;
    public bool megarayoChoose;
    public bool healthChoose;
    public bool currentBoost;
    // Start is called before the first frame update
    void Start()
    {
        boostList[0].onClick.AddListener(MeteorClic);
        boostList[1].onClick.AddListener(MegaRayoClic);
        boostList[2].onClick.AddListener(HealthClic);
    }

    // Update is called once per frame
    void Update()
    {
        if (meteoritChoose) {
            Debug.Log("meteorchoose");
        }
        if (megarayoChoose) {
            Debug.Log("megarayoChoose");
        }
        if (healthChoose) {
            Debug.Log("healtChoose");
        }

    }
    public void MeteorClic() {
        meteoritChoose = true;
        megarayoChoose = false;
        healthChoose = false;
    }
    public void MegaRayoClic() {
        meteoritChoose = false;
        megarayoChoose = true;
        healthChoose = false;
    }
    public void HealthClic() {
        meteoritChoose = false;
        megarayoChoose = false;
        healthChoose = true;
    }
}
