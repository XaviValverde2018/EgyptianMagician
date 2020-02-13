using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApofisLookAt : MonoBehaviour
{
    public GameObject _targetLookAt_elJugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_targetLookAt_elJugador.transform);
    }
}
