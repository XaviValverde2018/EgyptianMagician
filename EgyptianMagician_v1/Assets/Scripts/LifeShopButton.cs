using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeShopButton : MonoBehaviour
{
    //this code is in life shop Button
    /*
     1. Clicar al botó augmentem +5 al playerpref: "LifePP" 
     2. Tancar el set active
     3. restar els diners. Comprovar si tenim diners per a poder comprar.  
    */
    public int goldPlayer;
    public Button lifeButton;
    public Text numberbuy;
    public int numberbuyint;
    public GameObject _canvasShop; //per tancar al comprar pero de moment no s'utilitza
    public int LifePPBuyIncrement;
    public Text priceText;
    public int priceTextInt;
    public int preuESTABLERT;
    // Start is called before the first frame update
    void Start()
    {
        preuESTABLERT = 3;
        numberbuyint = 0;
        LifePPBuyIncrement = 0;// per testejar
        PlayerPrefs.SetInt("LifePPBuy", LifePPBuyIncrement);//per testejar        

        
        PlayerPrefs.SetInt("LifePPBuy", 0);
        if (numberbuyint == 0) {
            priceTextInt = preuESTABLERT;
            priceText.text = priceTextInt.ToString();
        }
        goldPlayer = PlayerPrefs.GetInt("goldValue");
    }

    // Update is called once per frame
    void Update()
    {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
        if (goldPlayer >= priceTextInt) {
            lifeButton.interactable = true;

        } else {
            lifeButton.interactable = false;
        }
    }
    public void LifeShopButtonFunction() {

        StartCoroutine(timerLifeGUI());
        
        
 
    }
    IEnumerator timerLifeGUI() {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
        goldPlayer -= priceTextInt; // = 110-180
        numberbuyint++; // 3/60
        LifePPBuyIncrement += 5;

        PlayerPrefs.SetInt("goldValue", goldPlayer);

        priceTextInt *= numberbuyint; //60*3 = 180.
        numberbuy.text = numberbuyint.ToString(); //3
        priceText.text = priceTextInt.ToString(); //180

        PlayerPrefs.SetInt("LifePPBuy", LifePPBuyIncrement);

        yield return new WaitForSeconds(0.5f);
        //_canvasShop.SetActive(false);
        Debug.Log("LifePPBuy: " + PlayerPrefs.GetInt("LifePPBuy"));
    }
}
