using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisTeleport : MonoBehaviour
{
    public GameObject teleport1;
    public GameObject teleport2; 
    public GameObject teleport3;
    public float elapsedTime;
    public float fireRate;
    public GameObject _psteleport1On;
    public GameObject _psteleport1Off;
    public GameObject _psteleport2On;
    public GameObject _psteleport2Off;
    public GameObject _psteleport3On;
    public GameObject _psteleport3Off;
    public GameObject _anubisPort; 


    // Start is called before the first frame update
    void Start()
    {
        fireRate = 3.0f;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        TeleportPosition();
    }
    private void TeleportPosition() {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >=0 && elapsedTime <= fireRate) {
            StartCoroutine(IEteleport2());
        }
        if(elapsedTime > fireRate && elapsedTime <= (fireRate*2)) {
            StartCoroutine(IEteleport1());
        }
        if(elapsedTime > (fireRate*2) && elapsedTime <= (fireRate*3)) {
            StartCoroutine(IEteleport3());
        }
        if(elapsedTime <0 || elapsedTime > (fireRate*3)) {
            elapsedTime = 0f;
        }
    }

    IEnumerator IEteleport2() {
        _psteleport1Off.SetActive(true);
        _psteleport2On.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        _psteleport1Off.SetActive(false);
        this.gameObject.transform.position = new Vector3(teleport2.transform.position.x,gameObject.transform.position.y,teleport2.transform.position.z);
        yield return new WaitForSeconds(0.3f);
        _psteleport2On.SetActive(false);
    }
    IEnumerator IEteleport1() {
        _psteleport1On.SetActive(true);
        _psteleport2Off.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        _psteleport2Off.SetActive(false);
        this.gameObject.transform.position = new Vector3(teleport1.transform.position.x, gameObject.transform.position.y, teleport1.transform.position.z);
        yield return new WaitForSeconds(0.3f);
        _psteleport1On.SetActive(false);
    }
    IEnumerator IEteleport3() {
        _psteleport3On.SetActive(true);
        _psteleport2Off.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        _psteleport2Off.SetActive(false);
        this.gameObject.transform.position = new Vector3(teleport3.transform.position.x, gameObject.transform.position.y, teleport3.transform.position.z);
        yield return new WaitForSeconds(0.3f);
        _psteleport3On.SetActive(false);
    }
}
