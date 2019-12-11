using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseGameObject;

    private void Start() {
        pauseGameObject.SetActive(false);
    }
    public void pauseGame() {
        if (isPaused) {
            Time.timeScale = 1;
            isPaused = false;
        } else {
            Time.timeScale = 0;
            isPaused = true;
            pauseGameObject.SetActive(true);
        }
    }

}
