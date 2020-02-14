using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class MeteorBehavior : MonoBehaviour
{
    public GameObject meteoritoPREFAB;
    public GameObject meteoritoPREFAB1;
    public GameObject meteoritoPREFAB2;
    public float randomvalue;
    public Button meteorButton;
    public bool meteorActivated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivarMeteorito() {
        randomvalue = Random.Range(1, 2);
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown() {
        /*meteorButton.interactable = true;
        yield return new WaitForSeconds(0.1f);
        meteorButton.interactable = false;
        meteoritoPREFAB.SetActive(true);
        yield return new WaitForSeconds(3);
        meteoritoPREFAB.SetActive(false);
        meteorButton.interactable = true;*/
        if(randomvalue == 1) {
            meteorButton.interactable = true;
            yield return new WaitForSeconds(0.1f);
            meteorButton.interactable = false;
            //Instantiate(meteoritoPREFAB1, meteoritoPREFAB1.transform);
            meteoritoPREFAB1.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            meteoritoPREFAB1.SetActive(false);
            yield return new WaitForSeconds(10);
            meteorButton.interactable = true;
        }
        if(randomvalue == 2) {
            meteorButton.interactable = true;
            yield return new WaitForSeconds(0.1f);
            meteorButton.interactable = false;
            meteoritoPREFAB2.SetActive(true);
            yield return new WaitForSeconds(1.5f);
           meteoritoPREFAB2.SetActive(false);
            yield return new WaitForSeconds(10);
            meteorButton.interactable = true;
        } 
    }
}
