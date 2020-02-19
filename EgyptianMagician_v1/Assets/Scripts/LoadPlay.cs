using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadPlay : MonoBehaviour
{
   public void Play() {
        SceneManager.LoadScene("SALA1802_tutorial");
    }
    public void Menu() {
        SceneManager.LoadScene("menu_principal");
        //SceneManager.LoadScene(7);
    }
    public void Settings() {
        SceneManager.LoadScene("settings");
    }
}
