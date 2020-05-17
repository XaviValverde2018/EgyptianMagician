using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //EN ESTE SCRIPT SE UNIFICARA TODA LA LOGICA PASADA LA ALPHA. 
    [Header("EnemiesList")]
    public GameObject[] enemiesFindingRoom;
    public int countEnemiesFindingRoomWithTag;
    public GameObject potsAnarAlSeguentNivell;

    [Header("Gold Status")]
    public int totalGold;
    public Text textGold;

    [Header("Exp Status")]
    public int totalExp;
    public int currentExpToChangeLevel;
    public Text textExp;
    public Slider sliderExp;
    public float totalvalueexp;
    public int LevelsValueExp; // PlayerPrefs.GetInt("LevelExpPP")
    public GameObject[] LevelExpImage;
    public int expValuePP;

    [Header("Bird Activated")]
    public ActiveBird _activeBird;
    public bool GM_BirdActivated;
    public PlayerController _PC;
    public GameObject gameOverScreen;

    [Header("PlayerPrefs")]
    public bool meteorBoolPlayerPrefs;
    public int meteorBoolPlayerPrefsValue;
    public bool healthBoolPlayerPrefs;
    public int healthBoolPlayerPrefsValue;
    public float MeteoritoPPBuy;
    public float HealthPPBuy;

    // Start is called before the first frame update

    void Start()
    {
    

        currentExpToChangeLevel = 0;
        LevelsValueExp = 0;
      
        totalExp = PlayerPrefs.GetInt("expValue");
        PlayerPrefs.SetInt("LevelExpPP",LevelsValueExp);


        MeteoritoPPBuy = PlayerPrefs.GetFloat("MeteoritoPPBuy");
        HealthPPBuy = PlayerPrefs.GetFloat("HealthPPBuy");
        //Time.timeScale = 1;

        meteorBoolPlayerPrefsValue = PlayerPrefs.GetInt("meteorBool");
        if(meteorBoolPlayerPrefsValue == 1) {
            meteorBoolPlayerPrefs = true;
        }
        if(meteorBoolPlayerPrefsValue == 0) {
            meteorBoolPlayerPrefs = false;
        }
        healthBoolPlayerPrefsValue = PlayerPrefs.GetInt("healthBool");
        if (healthBoolPlayerPrefsValue == 1) {
            healthBoolPlayerPrefs = true;
        }
        if(healthBoolPlayerPrefsValue == 0) {
            healthBoolPlayerPrefs = false;
        }

        countEnemiesFindingRoomWithTag = 99;
        enemiesFindingRoom = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemiesFindingRoom);
        GM_BirdActivated = _activeBird.birdActivated;

        //Eliminar aquesta linea de codi
        //PlayerPrefs.DeleteKey("expValue");

        //totalvalueexp = PlayerPrefs.GetInt("expValue");

        //PlayerPrefs.SetInt("goldValue", 999); // Hauria de ser 0 al principi del joc. 
        totalGold = PlayerPrefs.GetInt("goldValue");

    }

    // Update is called once per frame
    void Update()
    {
        MeteoritoPPBuy = PlayerPrefs.GetFloat("MeteoritoBuyIncrementPP");
        HealthPPBuy = PlayerPrefs.GetFloat("HealthPPBuy");

        BuscarEnemicsPerPasarAlSeguentNivell();
        GM_BirdActivated = _activeBird.birdActivated;
        totalGold = PlayerPrefs.GetInt("goldValue");
        textGold.text = totalGold.ToString();

        Debug.Log(PlayerPrefs.GetInt("healthBool"));
        Debug.Log(PlayerPrefs.GetInt("meteorBool"));

        // currentExpToChangeLevel = totalExp;
        //PlayerPrefs.SetInt("expValue", (expValuePP+=totalExp));
        //expValuePP = PlayerPrefs.GetInt("expValue");
        //PlayerPrefs.SetInt("goldValue", totalGold); // 23 de Març 2020


        LevelExpBehavior();
        //PlayerPrefs.SetInt("expValue", totalExp);
        if (_PC.lifePlayer <= 0)
            StartCoroutine(GameOver());

    }



    void BuscarEnemicsPerPasarAlSeguentNivell() {
        //Debug.Log("countEnemiesFindingRoomWithTag: " + countEnemiesFindingRoomWithTag);
        countEnemiesFindingRoomWithTag = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesFindingRoom = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemiesFindingRoom);
        if (countEnemiesFindingRoomWithTag == 0) { // Activem el prefab per anar a la seguent escena. 
            Debug.Log("no enemy");
            //potsAnarAlSeguentNivell.SetActive(true);
            //SceneManager.LoadScene("gameoverwin");
        } else {
            //potsAnarAlSeguentNivell.SetActive(false);
        }
    }// Serveix per buscar a un array d'enemics i si es 0 activar pasar a nivell seguent. 

    IEnumerator GameOver() {
        yield return new WaitForSeconds(2);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
      
    }
    public void LevelExpBehavior() {

        if (sliderExp.value == 1) {
            sliderExp.value = 0;
            currentExpToChangeLevel = 0;
            totalExp = 0;
            LevelsValueExp += 1;
            PlayerPrefs.SetInt("LevelExpPP", LevelsValueExp);
            LevelExpImage[LevelsValueExp - 1].SetActive(false);
            LevelExpImage[LevelsValueExp].SetActive(true);
        } else {
            currentExpToChangeLevel = totalExp;
            sliderExp.value = (currentExpToChangeLevel / 60.0f);
        }

 
    }


}
