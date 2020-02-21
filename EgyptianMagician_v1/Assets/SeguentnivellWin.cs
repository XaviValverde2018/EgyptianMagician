using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SeguentnivellWin : MonoBehaviour
{
    //This code is in potsAnarAlSeguentNivell prefab.
    public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;
    public int countEnemicsLlista;
    BoxCollider bc;   
    public string seguentnivell;
    public GameObject win;
    public GameObject ps;
    public Animator _camerashake;
    public AudioSource _a1;
    public AudioSource _a2;

    // Start is called before the first frame update
    void Start() {
        bc = GetComponent<BoxCollider>();

        bc.isTrigger = false;
    }

    // Update is called once per frame
    void Update() {
        ActivarPasadorDeNivell();
    }
    void ActivarPasadorDeNivell() {
        countEnemicsLlista = _comprobacioEnemicMesAprop.llistaEnemics.Count;
        if (countEnemicsLlista <= 0) {
            bc.isTrigger = true;

        } else {
            bc.isTrigger = false;
            
        }
        Debug.Log("countEnemicsLlista: " + countEnemicsLlista);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ps.SetActive(true);
            _camerashake.SetBool("isShake", true);
            StartCoroutine(countdown());
            _a1.Pause();
            _a2.Play();

        }
    }
    IEnumerator countdown() {
        yield return new WaitForSeconds(3);
       // ps.SetActive(false);
       // _camerashake.SetBool("isShake", false);
        win.SetActive(true);
    }
}
