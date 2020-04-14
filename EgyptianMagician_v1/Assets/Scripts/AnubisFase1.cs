using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnubisFase1 : MonoBehaviour
{
    public AnubisManager _anubisLifeManager;
    public float _anubisLifeNextFase;
    public string seguentFase; 
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        // de fase 1 a 2 quan la vida es menys del 50%
        if(_anubisLifeManager.AnubisLife <= _anubisLifeNextFase) {
            SceneManager.LoadScene(seguentFase);
        }
    }
}
