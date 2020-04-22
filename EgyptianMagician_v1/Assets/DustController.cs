using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustController : MonoBehaviour
{
    [Header("dustAll")]
    public GameObject dustAll;
    public float random_min;
    public float random_max;

    [Header("dustSphere")]
    public GameObject dustSphere;

    // Start is called before the first frame update
    void Start()
    {
        random_min = Random.Range(1, 4);
        random_max = Random.Range(4, 7);

        ActiveRandomDustAll();
        ActiveRandomDustSphere();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActiveRandomDustAll() {
        if((random_min == 2)||(random_max == 5)){
            dustAll.SetActive(true);
        } else {
            dustAll.SetActive(false);
        }
    }
    void ActiveRandomDustSphere() {
        if ((random_min == 1) || (random_max == 4)) {
            dustSphere.SetActive(true);
        } else {
            dustSphere.SetActive(false);
        }
    }


}
