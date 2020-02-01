using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoostPrefab : MonoBehaviour
{
    //This code is in ChooseBoost. Use for active Behavior Boost.
    public ActiveBoost Time_boost;
    public GameObject meteoritoPREFAB;
    public GameObject megarayoPREFAB;
    public GameObject healtPREFAB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time_boost.meteorBool) {
            MeteorBehavior();
        }
        if (Time_boost.megarayoBool) {
            megarayoBehavior();
        }
        if (Time_boost.healthBool) {
            healthBehavior();
        }
    }
    void MeteorBehavior() {
        meteoritoPREFAB.SetActive(true);
        megarayoPREFAB.SetActive(false);
        healtPREFAB.SetActive(false);
    }
    void megarayoBehavior() {
        meteoritoPREFAB.SetActive(false);
        megarayoPREFAB.SetActive(true);
        healtPREFAB.SetActive(false);
    }
    void healthBehavior() {
        meteoritoPREFAB.SetActive(false);
        megarayoPREFAB.SetActive(false);
        healtPREFAB.SetActive(true);
    }
}
