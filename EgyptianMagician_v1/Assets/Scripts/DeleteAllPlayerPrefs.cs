using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.DeleteKey("HealthBuyIncrementPP");
        PlayerPrefs.DeleteKey("MeteoritoBuyIncrementPP");
        PlayerPrefs.DeleteKey("SpeedBuyIncrementPP");
        PlayerPrefs.DeleteKey("LifeBuyIncrementPP");

        PlayerPrefs.DeleteKey("MeteoritoPPBuy");
        PlayerPrefs.DeleteKey("HealthPPBuy");

        PlayerPrefs.DeleteKey("goldValue");
        PlayerPrefs.DeleteKey("expValue");
        PlayerPrefs.DeleteKey("LevelExpPP");

        PlayerPrefs.DeleteKey("meteorBool");
        PlayerPrefs.DeleteKey("healthBool");

        PlayerPrefs.DeleteKey("numberbuyMeteorPP");
        PlayerPrefs.DeleteKey("priceTextIntMeteorPP");

        PlayerPrefs.DeleteKey("numberbuySpeedPP");
        PlayerPrefs.DeleteKey("priceTextIntSpeedPP");
        PlayerPrefs.DeleteKey("numberbuyHealthPP");
        PlayerPrefs.DeleteKey("priceTextIntHealthPP");
        PlayerPrefs.DeleteKey("numberbuyLifePP");
        PlayerPrefs.DeleteKey("priceTextIntLifePP");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
