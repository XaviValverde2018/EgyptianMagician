using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopButtonCanvasCode : MonoBehaviour
{

    public int goldPlayer;
    public Text goldPlayerText;

    // Start is called before the first frame update
    void Start()
    {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
    }

    // Update is called once per frame
    void Update()
    {
        goldPlayer = PlayerPrefs.GetInt("goldValue");
        goldPlayerText.text = goldPlayer.ToString();

    }
    public void BackButton() {
        this.gameObject.SetActive(false);
    }
}
