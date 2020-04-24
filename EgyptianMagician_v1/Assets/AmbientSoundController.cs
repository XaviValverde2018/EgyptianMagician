using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AmbientSoundController : MonoBehaviour
{
    public AudioSource ambientsound;
    public int numMusic;
    // Start is called before the first frame update
    void Start() {
        if (!ambientsound.isPlaying) { ambientsound.Play(); }
        numMusic = FindObjectsOfType<AudioSource>().Length;
        if(numMusic != 1) {
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update() {
        if ((SceneManager.GetActiveScene().name == "menu_principal_GOOD")|| (SceneManager.GetActiveScene().name == "logros") || (SceneManager.GetActiveScene().name == "settings") || (SceneManager.GetActiveScene().name == "sala_mapas")) {
            this.gameObject.SetActive(true);
            DontDestroyOnLoad(this.gameObject);
        } else {
            this.gameObject.SetActive(false);
        }

    }

}
