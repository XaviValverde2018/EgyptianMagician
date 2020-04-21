using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMeteoritoNull : MonoBehaviour
{
    // Start is called before the first frame update
    public float timerMeteoritoUpgrade;
    //public GameManager _gm;
    void Start()
    {
       // _gm = GameObject.FindObjectOfType<GameManager>();
        timerMeteoritoUpgrade = PlayerPrefs.GetFloat("MeteoritoBuyIncrementPP");
        if (timerMeteoritoUpgrade <= 0) {
            timerMeteoritoUpgrade = 3.0f;
        }
        this.transform.parent = null;
        //timerMeteoritoUpgrade = PlayerPrefs.GetFloat("MeteoritoPPBuy");

        StartCoroutine(CountDown());
        

    }

    // Update is called once per frame
    void Update()
    {

        //timerMeteoritoUpgrade = PlayerPrefs.GetFloat("MeteoritoPPBuy");
    }
    IEnumerator CountDown() {
        yield return new WaitForSeconds(timerMeteoritoUpgrade);
        Destroy(this.gameObject);
    }
}
