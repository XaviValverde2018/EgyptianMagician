using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMeteoritoNull : MonoBehaviour
{
    // Start is called before the first frame update
    public float timerMeteoritoUpgrade;

    void Start()
    {
        this.transform.parent = null;
        StartCoroutine(CountDown());
        timerMeteoritoUpgrade = PlayerPrefs.GetFloat("MeteoritoPPBuy");

    }

    // Update is called once per frame
    void Update()
    {
        timerMeteoritoUpgrade = PlayerPrefs.GetFloat("MeteoritoPPBuy");
        Debug.Log("timerMeteoritoUpgrade" + timerMeteoritoUpgrade);
        Debug.Log(" PlayerPrefs.GetFloat(MeteoritoPPBuy)" + PlayerPrefs.GetFloat("MeteoritoPPBuy"));
    }
    IEnumerator CountDown() {
        yield return new WaitForSeconds(timerMeteoritoUpgrade);
        Destroy(this.gameObject);
    }
}
