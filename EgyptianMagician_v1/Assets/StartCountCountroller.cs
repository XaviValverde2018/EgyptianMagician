using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountCountroller : MonoBehaviour
{

    [Header("StartCount")]
    public Animator animStartCount;
    public GameObject StartCountCanvas;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCount());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartCount() {
        StartCountCanvas.SetActive(true);
        animStartCount.SetBool("StartCount", true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        StartCountCanvas.SetActive(false);

    }
}
