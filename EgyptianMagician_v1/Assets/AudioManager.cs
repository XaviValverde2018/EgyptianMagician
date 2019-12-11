using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource ambientsound;
    public AudioSource atack_horus;
    public AudioSource mummy_mouth;
    public AudioSource Horus_Damage;
    public AudioSource win;

    public bool isSilence;
    // Start is called before the first frame update
    void Start()
    {
        isSilence = false;
        ambientsound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Silence() {
        //ambientsound.mute = !ambientsound.mute;
       if (!isSilence) {
            ambientsound.Pause();
            isSilence =! isSilence;
        } else {
            ambientsound.Play();
            isSilence = !isSilence;
        }

    }

}
