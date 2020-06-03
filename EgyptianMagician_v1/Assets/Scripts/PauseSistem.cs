using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSistem : MonoBehaviour
{
    public GameObject audiomanager;
    public bool mute; 
    // Start is called before the first frame update
    void Start()
    {
        mute = false;
        audiomanager = GameObject.FindGameObjectWithTag("audiomanager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mute() {
        //if(mute) {
            audiomanager.SetActive(mute);
            mute = !mute;
      //  }
        /*if (mute == false) {
            audiomanager.SetActive(mute);
            mute = true;
        }*/
    }
    public void UnMute() {
        audiomanager.SetActive(false);
    }
}
