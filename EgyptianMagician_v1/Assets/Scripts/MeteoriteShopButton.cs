using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MeteoriteShopButton : MonoBehaviour
{
    //this code is in Meteorite shop Button
    /*
     1. Clicar al botó augmentem +5 al playerpref: "MeteoritoPPBuy". valor el Jugador: parentnulll seconds 
     2. Tancar el set active
     3. restar els diners. Comprovar si tenim diners per a poder comprar.  
    */
    [Header("ValuePP")]
    public int goldPlayer; //serveix per saber quants diners tenim en el moment. 
    public int preuESTABLERT; //serveix per marcar un preu d'inici

    [Header("ValueCanvas")]
    public int priceTextInt; //el valor del preu del que val el producte
    public Text priceText; //el valor del preu del que val el producte TEXT. 
    public Button MeteoriteButton; // Botón para comprar

    [Header("ValuePurchases")]
    public int numberbuyint; //el numero de vegades que hem comprat
    public Text numberbuy; // el numero de vegades que hem comprat TEXT.


    [Header("PlayerPrefMeteorito")]
    public float MeteoritoPPBuyIncrement;

    // Start is called before the first frame update
    void Start()
    {
        goldPlayer = PlayerPrefs.GetInt("goldValue");

        preuESTABLERT = 100;
        numberbuyint = 0;
        MeteoritoPPBuyIncrement = 0;

        //PlayerPrefs.SetFloat("MeteoritoPPBuy", MeteoritoPPBuyIncrement);

        if (numberbuyint == 0) {
            priceTextInt = preuESTABLERT;
            priceText.text = priceTextInt.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
        if (goldPlayer >= priceTextInt) {
            MeteoriteButton.interactable = true;
        } else {
            MeteoriteButton.interactable = false;
        }
    }
    public void MeteoritoShopButtonFunction() {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
        goldPlayer -= priceTextInt;
        numberbuyint++;
        MeteoritoPPBuyIncrement += 1.0f;
        PlayerPrefs.SetInt("goldValue", goldPlayer);
        priceTextInt *= numberbuyint;
        numberbuy.text = numberbuyint.ToString();
        priceText.text = priceTextInt.ToString();

        PlayerPrefs.SetFloat("MeteoritoPPBuy", MeteoritoPPBuyIncrement);
        Debug.Log(" APlayerPrefs.GetFloat(MeteoritoPPBuy)" + PlayerPrefs.GetFloat("MeteoritoPPBuy"));
       
    }
    IEnumerator timerMeteoritoGUI() {
        yield return new WaitForSeconds(0.1f);
        //_canvasShop.SetActive(false);
    }

}

