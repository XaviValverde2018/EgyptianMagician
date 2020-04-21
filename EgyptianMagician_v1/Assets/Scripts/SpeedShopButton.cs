using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedShopButton : MonoBehaviour
{
    //this code is in Speed shop Button
    /*
     1. Clicar al botó augmentem +5 al playerpref: "SpeedPP". valor el Jugador: firerate 
     2. Tancar el set active
     3. restar els diners. Comprovar si tenim diners per a poder comprar.  
    */
    [Header("ValuePP")]
    public int goldPlayer; //serveix per saber quants diners tenim en el moment. 
    public int preuESTABLERT; //serveix per marcar un preu d'inici

    [Header("ValueCanvas")]
    public int priceTextInt; //el valor del preu del que val el producte
    public Text priceText; //el valor del preu del que val el producte TEXT. 
    public Button SpeedButton; // Botón para comprar

    [Header("ValuePurchases")]
    public int numberbuyint; //el numero de vegades que hem comprat
    public Text numberbuy; // el numero de vegades que hem comprat TEXT.

    [Header("PlayerPrefSpeed")]
    public float SpeedPPBuyIncrement;

    // Start is called before the first frame update
    void Start()
    {
        goldPlayer = PlayerPrefs.GetInt("goldValue");

        preuESTABLERT = 80;
        numberbuyint = PlayerPrefs.GetInt("numberbuySpeedPP");
        priceTextInt = PlayerPrefs.GetInt("priceTextIntSpeedPP"); //priceTextInt = preu establert; TUTORIAL
        SpeedPPBuyIncrement = PlayerPrefs.GetFloat("SpeedBuyIncrementPP");
        numberbuy.text = numberbuyint.ToString();
        priceText.text = priceTextInt.ToString();


        if(numberbuyint == 0) {
            priceTextInt = preuESTABLERT;
            priceText.text = priceTextInt.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
        if(goldPlayer >= priceTextInt) {
            SpeedButton.interactable = true;
        } else {
            SpeedButton.interactable = false;
        }
    }

    public void SpeedShopButtonFunction() {
        StartCoroutine(timerSpeedGUI());
    }

    IEnumerator timerSpeedGUI() {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
        goldPlayer -= priceTextInt;
        numberbuyint++;
        SpeedPPBuyIncrement += 0.02f;

        PlayerPrefs.SetInt("goldValue", goldPlayer);

        priceTextInt *= numberbuyint;
        numberbuy.text = numberbuyint.ToString();
        priceText.text = priceTextInt.ToString();

        PlayerPrefs.SetInt("numberbuySpeedPP", numberbuyint);
        PlayerPrefs.SetInt("priceTextIntSpeedPP", priceTextInt);
        PlayerPrefs.SetFloat("SpeedBuyIncrementPP", SpeedPPBuyIncrement);

        yield return new WaitForSeconds(0.5f);
        //_canvasShop.SetActive(false);
    }
}
