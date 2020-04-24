using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piramideDie : MonoBehaviour
{
    public EnemyManager _em;
    public AudioSource soundPiramide; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_em.vidaEnemics <= 0) {
            if (!soundPiramide.isPlaying) { soundPiramide.Play(); }
        }
    }
}
