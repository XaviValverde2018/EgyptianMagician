using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class God : MonoBehaviour
{
    /*
     * p = pause tot per ensenyar
     * o = unpause
     * i = life infinit. 
     * y = menu principal
     * t = modo volar
     * r = reset gameplay
     * e = reset all game
     * ESC = sortir tot
     * */

    // Update is called once per framed
    public bool lifeplayergod=false;
    public HitTarget ht;

    private void Start() {
        lifeplayergod = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {//pause a tot
            Time.timeScale=0;
        }
        if (Input.GetKeyDown(KeyCode.O)) { 
            Time.timeScale=1;
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            lifeplayergod = true;
            ht.health = 999;
        }
        if (Input.GetKeyDown(KeyCode.U)) {
            lifeplayergod = false;
            ht.health = 10;
        }
 
        if (Input.GetKeyDown(KeyCode.Y)) {
            SceneManager.LoadScene("menu_principal");
        }
   
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("lvl1");
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene("logo");
        }

    }
}
