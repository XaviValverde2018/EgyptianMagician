using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableShop : MonoBehaviour
{

    public GameObject canvasShop;

    /*
     totalvalueexp = PlayerPrefs.GetInt("expValue");
        totalGold = PlayerPrefs.GetInt("goldValue");
     */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            canvasShop.SetActive(true);
        }
    }
}
