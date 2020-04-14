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
        SceneManager.LoadScene("SALA1902_02");
    }
    public void lvl2() {
        SceneManager.LoadScene("SALA1902_03");
    }
    public void lvl3() {
        SceneManager.LoadScene("SALA1902_04");
    }
    public void lvl4() {
        SceneManager.LoadScene("SALA1902_05");
    }
    public void lvl5() {
        SceneManager.LoadScene("SALA1902_06");
    }
    public void lvl6() {
        SceneManager.LoadScene("SALA1902_07");
    }
    public void lvl7() {
        SceneManager.LoadScene("SALA1902_08");
    }
    public void lvl8() {
        SceneManager.LoadScene("SALA1902_09");
    }
    public void lvl9() {
        SceneManager.LoadScene("SALA1902_10");
    }
    public void Home() {
        SceneManager.LoadScene("menu_principal_GOOD");
    }

}
