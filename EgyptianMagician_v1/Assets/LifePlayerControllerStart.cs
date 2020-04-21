using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayerControllerStart : MonoBehaviour
{
    public float StartLifePlayer;
    public bool CounterStartLife;
    // Start is called before the first frame update
    void Start()
    {
        CounterStartLife = false;
        StartLifePlayer = 30;
        PlayerPrefs.SetFloat("CurrentLifePlayer", StartLifePlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (CounterStartLife) {
            PlayerPrefs.SetFloat("CurrentLifePlayer", StartLifePlayer);
        } else {
            StartCoroutine(Counter());

        }
    }
    IEnumerator Counter() {
        yield return new WaitForSeconds(3);
        CounterStartLife = true;
    }

}
