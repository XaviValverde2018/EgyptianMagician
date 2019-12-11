using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseCanvasSystem : MonoBehaviour
{
    public GameObject pauseGameObject;
    public PauseSystem pausesystem;
    public void Replay() {
        pauseGameObject.SetActive(false);
        Time.timeScale = 1;
        pausesystem.isPaused = false;
    }

    public void BackToMenu() {
        SceneManager.LoadScene("menu_principal");
    }

}
