using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisEndController : MonoBehaviour
{
    public AnubisManager _am;
    public AudioSource AudioVictory;
    public AudioSource AudioFiveToDeath;
    public AudioSource AudioOneToDeath;
    public Animator shakeCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_am.AnubisLife < 13) {
            shakeCamera.SetBool("isShake", true);
            if (!AudioFiveToDeath.isPlaying) { AudioFiveToDeath.Play(); }
        }
        if(_am.AnubisLife < 5) {
            if (!AudioOneToDeath.isPlaying) { AudioOneToDeath.Play(); }
        }
        if(_am.AnubisLife <= 0) {
            if (!AudioVictory.isPlaying) { AudioVictory.Play(); }
        }
    }
}
