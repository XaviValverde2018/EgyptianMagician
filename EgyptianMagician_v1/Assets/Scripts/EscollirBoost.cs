using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EscollirBoost : MonoBehaviour
{
    //This code is in ChooseButtonCanvas 
    public Button[] boostList;
    public bool meteoritChoose;
    public bool megarayoChoose;
    public bool healthChoose;
    public bool NullBoost;
    public GameObject meteorButton;
    public GameObject healthButton;
    // Start is called before the first frame update

    void Start()
    {
        NullBoost = true;
        boostList[0].onClick.AddListener(MeteorClic);
        boostList[1].onClick.AddListener(MegaRayoClic);
        boostList[2].onClick.AddListener(HealthClic);
        Debug.Log(PlayerPrefs.GetInt("healthBool"));
        Debug.Log(PlayerPrefs.GetInt("meteorBool"));
    }

    // Update is called once per frame
    void Update()
    {
        if (meteoritChoose) {
            Debug.Log("meteorchoose");
            meteorButton.SetActive(true);
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("SALA1_BETA");// aixo s'ha de cambiar per sala tutorial normal.

        }
        if (megarayoChoose) {
            Debug.Log("megarayoChoose");
        }
        if (healthChoose) {
            Debug.Log("healtChoose");
            healthButton.SetActive(true);
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("SALA1_BETA");
            Debug.Log(PlayerPrefs.GetInt("healthBool"));
            Debug.Log(PlayerPrefs.GetInt("meteorBool"));

        }
        /*
        if (NullBoost == false) {// Modificar per a cambiar a 1 cop
            this.gameObject.SetActive(false);
        }*/

    }
    public void MeteorClic() {
        PlayerPrefs.SetInt("meteorBool", 1);
        meteoritChoose = true;
        megarayoChoose = false;
        healthChoose = false;
        NullBoost = false;
    }
    public void MegaRayoClic() {
        meteoritChoose = false;
        megarayoChoose = true;
        healthChoose = false;
        NullBoost = false;
    }
    public void HealthClic() {
        PlayerPrefs.SetInt("healthBool", 1);
        meteoritChoose = false;
        megarayoChoose = false;
        healthChoose = true;
        NullBoost = false;
        
    }
}
