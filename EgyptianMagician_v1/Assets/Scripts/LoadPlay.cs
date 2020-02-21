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
        SceneManager.LoadScene("menu_principal_GOOD");
        //SceneManager.LoadScene(7);
    }
    public void Settings() {
        SceneManager.LoadScene("settings");
    }
    public void GameOverPlay() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
    public void SelectLevels() {
        SceneManager.LoadScene("sala_mapas");
    }
    public void Reload() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
