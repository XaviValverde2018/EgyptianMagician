using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostButtonManager : MonoBehaviour
{
    public GameManager _gm;
    public GameObject meteoritoButton;
    public GameObject healthButton;
    // Start is called before the first frame update
    void Start()
    {
        meteoritoPREFABactivado();
        healthPREFABactivado();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void meteoritoPREFABactivado() {
        if (_gm.meteorBoolPlayerPrefs) {
            meteoritoButton.SetActive(true);
        } else {
            meteoritoButton.SetActive(false);
        }
    }
    void healthPREFABactivado() {
        if (_gm.healthBoolPlayerPrefs) {
            healthButton.SetActive(true);
        } else {
            healthButton.SetActive(false);
        }
    }
}
