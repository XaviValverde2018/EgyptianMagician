using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisManager : MonoBehaviour
{
    public float AnubisLife;
    public bool AnubisMort;
    // Start is called before the first frame update
    void Start()
    {
        AnubisMort = false;
        AnubisLife = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
