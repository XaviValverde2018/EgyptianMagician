using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeController : MonoBehaviour
{
    //public Image LifeBar;
    //public float Fill;
    //public AudioSource damageHorus;
    //public God god_lifeplayer;
    public Text t1;
    public PlayerController _pc;
    // Start is called before the first frame update
    void Start()
    {
        //Fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       /* if(LifeBar.fillAmount <= 0.01f) {
            SceneManager.LoadScene("muerte");
        }*/
        t1.text = _pc.lifePlayer.ToString();

    }
    /*private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player")) {
            if (god_lifeplayer.lifeplayergod == false) {
                Fill -= Time.deltaTime * 0.1f;
                LifeBar.fillAmount = Fill;
            }   
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            damageHorus.Play();
        }
    }*/

}
