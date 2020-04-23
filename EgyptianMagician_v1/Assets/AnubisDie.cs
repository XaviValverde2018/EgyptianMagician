using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnubisDie : MonoBehaviour
{
    public AnubisManager _am;
    public Animator _animPortal;
    public PlayerController _pl;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(_am.AnubisLife <= 0) {
            _pl.FireRate = 80;
            _animPortal.SetBool("portalactive", true);
            StartCoroutine(CountWin());
        }
    }
    IEnumerator CountWin() {
        yield return new WaitForSeconds(8.0f);
        SceneManager.LoadScene("SALA1802_tutorial");
    }
}
