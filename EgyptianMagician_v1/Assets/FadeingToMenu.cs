using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeingToMenu : MonoBehaviour
{
    bool fadefin = false;
    public float timer = 0f;
    public Animator fadeanimator;
    // Start is called before the first frame update
    void Start()
    {
        timer = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        if (timer <= 3) {
            FadeToLevel();
            if (timer <= 1) {
                SceneManager.LoadScene("menu_principal");
            }

        }
    }

    public void Timer() {
        timer -= timer*Time.deltaTime;
    }
    public void FadeToLevel() {
        fadeanimator.SetBool("fadefin",true);
    }
}
