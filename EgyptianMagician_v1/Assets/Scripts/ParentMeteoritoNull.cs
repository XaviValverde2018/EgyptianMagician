using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMeteoritoNull : MonoBehaviour
{
    // Start is called before the first frame update
    public float timerMeteoritoUpgrade;
    public GameManager _gm;
    void Start()
    {
        _gm = GameObject.FindObjectOfType<GameManager>();
        timerMeteoritoUpgrade = _gm.MeteoritoPPBuy;
        if(timerMeteoritoUpgrade <= 0) {
            timerMeteoritoUpgrade = 1.0f;
        }
        this.transform.parent = null;
        //timerMeteoritoUpgrade = PlayerPrefs.GetFloat("MeteoritoPPBuy");

        StartCoroutine(CountDown());
        

    }

    // Update is called once per frame
    void Update()
    {

        //timerMeteoritoUpgrade = PlayerPrefs.GetFloat("MeteoritoPPBuy");
        Debug.Log("timerMeteoritoUpgrade" + timerMeteoritoUpgrade);
        Debug.Log(" PlayerPrefs.GetFloat(MeteoritoPPBuy)" + PlayerPrefs.GetFloat("MeteoritoPPBuy"));
    }
    IEnumerator CountDown() {
        yield return new WaitForSeconds(timerMeteoritoUpgrade);
        Destroy(this.gameObject);
    }
}
