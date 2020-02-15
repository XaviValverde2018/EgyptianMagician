using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class MeteorBehavior : MonoBehaviour
{
    public GameObject meteoritoPREFAB;
    public Button meteorButton;
    public bool meteorActivated;
    public GameObject meteoritoPointGenerate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivarMeteorito() {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown() {
        Instantiate(meteoritoPREFAB, meteoritoPointGenerate.transform);
        meteorButton.interactable = true;
        meteorActivated = true;
        yield return new WaitForSeconds(0.1f);
        meteorButton.interactable = false;
        yield return new WaitForSeconds(1.5f);
        meteorActivated = true;
        yield return new WaitForSeconds(10);
        meteorButton.interactable = true;
    }
}
