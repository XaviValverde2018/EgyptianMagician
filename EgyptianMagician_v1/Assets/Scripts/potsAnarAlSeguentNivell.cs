using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class potsAnarAlSeguentNivell : MonoBehaviour
{
    //This code is in potsAnarAlSeguentNivell prefab.
    public comprobacioEnemicMesAprop _comprobacioEnemicMesAprop;
    public int countEnemicsLlista;
    BoxCollider bc;
    ParticleSystem ps;
        // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        ps = GetComponent<ParticleSystem>();
        bc.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        ActivarPasadorDeNivell();
    }
    void ActivarPasadorDeNivell() {
        countEnemicsLlista = _comprobacioEnemicMesAprop.llistaEnemics.Count;
        if(countEnemicsLlista <= 0) {
            bc.isTrigger = true;
            ps.Play();
        } else {
            bc.isTrigger = false;
            ps.Stop();
        }
        Debug.Log("countEnemicsLlista: " + countEnemicsLlista);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(6);//6 = SALA 1
        }
    }
}
