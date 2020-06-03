using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnubisBossBattleMusic : MonoBehaviour
{
    public AudioSource audioBossBattle;
    // Start is called before the first frame update
    void Start()
    {
        if (!audioBossBattle.isPlaying) { audioBossBattle.Play(); }
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name == "SALA_ANUBIS")|| (SceneManager.GetActiveScene().name == "SALA_ANUBIS_2")|| (SceneManager.GetActiveScene().name == "SALA_ANUBIS_3")) {
            DontDestroyOnLoad(this.gameObject);            
        }
        if (SceneManager.GetActiveScene().name == "SALA_ANUBIS_3") {
            audioBossBattle.volume = 0.05f;
        } 
        if(SceneManager.GetActiveScene().name == "menu_principal_GOOD") {
            this.gameObject.SetActive(false);
        }

    }
}
