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
    public GameObject ps;
    public string seguentnivell;
    public Animator _animOpenDoorRight;
    public Animator _animOpenDoorLeft;

    // Start is called before the first frame update
    void Start()
    {
        _animOpenDoorLeft.SetBool("OpenDoorLeftBool", false);
        _animOpenDoorRight.SetBool("OpenDoorRightBool", false);

        bc = GetComponent<BoxCollider>();
        
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
            ps.SetActive(true);

            _animOpenDoorLeft.SetBool("OpenDoorLeftBool", true);
            _animOpenDoorRight.SetBool("OpenDoorRightBool", true);
        } else {
            bc.isTrigger = false;
            ps.SetActive(false);
        }
        Debug.Log("countEnemicsLlista: " + countEnemicsLlista);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(seguentnivell);//6 = SALA 1
        }
    }
}
