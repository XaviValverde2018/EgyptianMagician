using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lvl1(){
        SceneManager.LoadScene("SALA1802_tutorial");
    }
    public void lvl2() {
        SceneManager.LoadScene("SALA_ANUBIS");
    }
    public void Home() {
        SceneManager.LoadScene("menu_principal_GOOD");
    }

}
