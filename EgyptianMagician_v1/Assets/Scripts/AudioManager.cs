using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public AudioSource ambientsound;
    // Start is called before the first frame update
    void Start()
    {
        if (!ambientsound.isPlaying) { ambientsound.Play(); }
    }

    // Update is called once per frame
    void Update()
    {
        if((SceneManager.GetActiveScene().name == "SALA_ANUBIS")) {
            this.gameObject.SetActive(false);
        } else {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }


}
