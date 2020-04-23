using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentNull : MonoBehaviour {
    // Start is called before the first frame update
    public float timerHealthUpgrade;
    public AudioSource audioHealtharea;

   //public GameManager _gm;

    void Start() {
        //_gm = GameObject.FindObjectOfType<GameManager>();
        timerHealthUpgrade = PlayerPrefs.GetFloat("HealthBuyIncrementPP");
        if (timerHealthUpgrade <= 0) {
            timerHealthUpgrade = 3.0f;
        }
        this.transform.parent = null;
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update() {

    }
    IEnumerator CountDown() {
        if (!audioHealtharea.isPlaying) { audioHealtharea.Play(); }
        yield return new WaitForSeconds(timerHealthUpgrade);
        audioHealtharea.Stop();
        Destroy(this.gameObject);
    }
}
