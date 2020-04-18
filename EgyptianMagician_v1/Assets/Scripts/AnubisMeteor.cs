using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisMeteor : MonoBehaviour
{
    public GameObject meteoritoAnubisPREFAB;
    public GameObject CanvasMeteoritoAnubis;
    public Animator animationShakeCamera;
    public float elapsedTime;
    public float FireRate; 

    // Start is called before the first frame update
    void Start()
    {
        meteoritoAnubisPREFAB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(InvokeMeteoriteAnubis());
    }
    IEnumerator InvokeMeteoriteAnubis() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > FireRate) {
            meteoritoAnubisPREFAB.SetActive(true);
            animationShakeCamera.SetBool("isShake", true);
            yield return new WaitForSeconds(3);
            meteoritoAnubisPREFAB.SetActive(false);
            animationShakeCamera.SetBool("isShake", false);
            CanvasMeteoritoAnubis.SetActive(false);
            elapsedTime = 0;
        }
    }

}
