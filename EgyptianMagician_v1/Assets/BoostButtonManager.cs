using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostButtonManager : MonoBehaviour
{
    public GameManager _gm;
    public GameObject meteoritoPREFAB;
    // Start is called before the first frame update
    void Start()
    {
        meteoritoPREFABactivado();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void meteoritoPREFABactivado() {
        if (_gm.meteorBoolPlayerPrefs) {
            meteoritoPREFAB.SetActive(true);
        }
    }
}
