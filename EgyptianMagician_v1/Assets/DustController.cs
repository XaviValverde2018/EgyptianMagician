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
    public AudioSource audioDustSphere;
    public AudioSource audioDustAll;

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
            if (!audioDustAll.isPlaying) { audioDustAll.Play(); }
            dustAll.SetActive(true);
    }
    void ActiveRandomDustSphere() {
        if ((random_min == 1) || (random_max == 4)) {
            if (!audioDustSphere.isPlaying) { audioDustSphere.Play(); }
            dustSphere.SetActive(true);
        } else {
            dustSphere.SetActive(false);
            audioDustSphere.Stop();
        }
    }


}
