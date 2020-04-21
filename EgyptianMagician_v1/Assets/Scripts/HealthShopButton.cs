using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthShopButton : MonoBehaviour
{
    //this code is in AreaHealth shop Button
    /*
     * AreaHealth_VFX prefab
     1. Clicar al botó augmentem +5 al playerpref: "HealthPPBuy". valor el Jugador: ???? 
     2. Tancar el set active
     3. restar els diners. Comprovar si tenim diners per a poder comprar.  
    */
    [Header("ValuePP")]
    public int goldPlayer; //serveix per saber quants diners tenim en el moment. 
    public int preuESTABLERT; //serveix per marcar un preu d'inici

    [Header("ValueCanvas")]
    public int priceTextInt; //el valor del preu del que val el producte
    public Text priceText; //el valor del preu del que val el producte TEXT. 
    public Button HealthButton; // Botón para comprar

    [Header("ValuePurchases")]
    public int numberbuyint; //el numero de vegades que hem comprat
    public Text numberbuy; // el numero de vegades que hem comprat TEXT.


    [Header("PlayerPrefMeteorito")]
    public float HealthPPBuyIncrement;

    // Start is called before the first frame update
    void Start()
    {
        goldPlayer = PlayerPrefs.GetInt("goldValue");

        preuESTABLERT = 10;
        numberbuyint = PlayerPrefs.GetInt("numberbuyHealthPP");//numberbuyint = 0; TUTORIAL
        priceTextInt = PlayerPrefs.GetInt("priceTextIntHealthPP"); //priceTextInt = preu establert; TUTORIAL
        HealthPPBuyIncrement = PlayerPrefs.GetFloat("HealthBuyIncrementPP");
        numberbuy.text = numberbuyint.ToString();
        priceText.text = priceTextInt.ToString();

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
            HealthButton.interactable = true;
        } else {
            HealthButton.interactable = false;
        }
    }
    public void HealthShopButtonFunction() {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
        goldPlayer -= priceTextInt;
        numberbuyint++;
        HealthPPBuyIncrement += 1.0f;
        PlayerPrefs.SetInt("goldValue", goldPlayer);
        priceTextInt *= numberbuyint;
        numberbuy.text = numberbuyint.ToString();
        priceText.text = priceTextInt.ToString();

        PlayerPrefs.SetInt("numberbuyHealthPP", numberbuyint);
        PlayerPrefs.SetInt("priceTextIntHealthPP", priceTextInt);
        PlayerPrefs.SetFloat("HealthBuyIncrementPP", HealthPPBuyIncrement);

    }
}
