using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnubisManager : MonoBehaviour
{
    public float AnubisLife;
    public bool AnubisMort;
    public AnubisFase1 _anubisfase1;
    public float LifeFase1;
    public float LifeFase2;
    public float LifeFase3;

    //[Header("FASE1")]
    //public GameObject _meteoriteAnubisPREFAB;
    // Start is called before the first frame update
    void Start()
    {
        AnubisMort = false;
        AnubisLife = 100.0f;
        LifeFase1 = AnubisLife;
        LifeFase2 = (AnubisLife * 0.50f);
        LifeFase3 = (AnubisLife * 0.25f);

        if (SceneManager.GetActiveScene().name == "SALA_ANUBIS") {
            AnubisLife = LifeFase1;
        }
        if (SceneManager.GetActiveScene().name == "SALA_ANUBIS_FASE2") {
            AnubisLife = LifeFase2;
        }
        if (SceneManager.GetActiveScene().name == "SALA_ANUBIS_FASE3") {
            AnubisLife = LifeFase3;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(AnubisLife >= LifeFase2) {
           // MeteoriteAnubisTrue();
        }
        if(AnubisLife >= LifeFase3 && AnubisLife < LifeFase2) {
            //MeteoriteAnubisFalse();
            //_anubisfase2.enabled = true;
            // Escriure codi de la FASE 2. Fase 2: Invocacio d'enemics. 
        }
        if(AnubisLife < LifeFase3) {
          //  MeteoriteAnubisFalse();
            //_anubisfase2.enabled = false;
            //_anubisfase3.enabled = true;
        }       
 
        
    }
    //falta el trigger de quan li donen al anubis. 
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("bullet")) {
            DamagePlayerToAnubis();
            if (AnubisLife <= 0) {
                AnubisMort = true;
            } else {
                AnubisMort = false;
            }
        }
    }
    void DamagePlayerToAnubis() {
        AnubisLife--;
    }
    /*void MeteoriteAnubisTrue() {
        _meteoriteAnubisPREFAB.SetActive(true);
    }
    void MeteoriteAnubisFalse() {
        _meteoriteAnubisPREFAB.SetActive(false);
    }*/
}
