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
    public Animator animationMeteorito;
    public Animator animationShakeCamera;
    public float timeActiveMeteorito;
    // Start is called before the first frame update
    void Start()
    {
        timeActiveMeteorito = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeActiveMeteorito = PlayerPrefs.GetFloat("MeteoritoBuyIncrementPP");
    }
    public void ActivarMeteorito() {
        StartCoroutine(CountDown());
    }
    IEnumerator CountDown() {
        animationMeteorito.SetBool("isWalk", false);
        animationMeteorito.SetBool("isMeteorito", true);
        Instantiate(meteoritoPREFAB, meteoritoPointGenerate.transform);
        meteorButton.interactable = true;
        meteorActivated = true;
        yield return new WaitForSeconds(0.1f);
        meteorButton.interactable = false;
        animationShakeCamera.SetBool("isShake", true);
        yield return new WaitForSeconds(2.0f);
        animationMeteorito.SetBool("isWalk", true);
        animationMeteorito.SetBool("isMeteorito", false);    
        yield return new WaitForSeconds(timeActiveMeteorito);
        meteorActivated = true;
        animationShakeCamera.SetBool("isShake", false);
        yield return new WaitForSeconds(10);
        meteorButton.interactable = true;
    }
}
