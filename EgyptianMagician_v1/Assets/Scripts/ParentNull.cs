using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentNull : MonoBehaviour {
    // Start is called before the first frame update
    public float timerHealthUpgrade;
    public GameManager _gm;

    void Start() {
        _gm = GameObject.FindObjectOfType<GameManager>();
        timerHealthUpgrade = _gm.HealthPPBuy;
        if(timerHealthUpgrade <= 2) {
            timerHealthUpgrade = 3.0f;
        }
        this.transform.parent = null;
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update() {

    }
    IEnumerator CountDown() {
        yield return new WaitForSeconds(timerHealthUpgrade);
        Destroy(this.gameObject);
    }
}
