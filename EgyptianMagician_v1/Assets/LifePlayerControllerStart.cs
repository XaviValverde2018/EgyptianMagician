using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayerControllerStart : MonoBehaviour
{
    public float StartLifePlayer;
    public PlayerController _pl;
    // Start is called before the first frame update
    void Awake()
    {
        _pl.lifePlayer = StartLifePlayer;
        _pl.maxlifeplayer = 200;
        PlayerPrefs.SetFloat("CurrentLifePlayerPP", StartLifePlayer);
        PlayerPrefs.SetInt("ChangeValueLifePP", 1);
    }

    // Update is called once per frame
    void Update() { }
 

}
