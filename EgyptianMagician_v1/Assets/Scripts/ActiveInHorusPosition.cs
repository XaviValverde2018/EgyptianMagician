using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInHorusPosition : MonoBehaviour
{
    public GameObject _horusPosition;
    public AudioSource audioMeteoritoAnubis;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.position = new Vector3(_horusPosition.transform.position.x, this.transform.position.y, _horusPosition.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("HorusPosition", 4);
    }
    public void HorusPosition() {
        if (!audioMeteoritoAnubis.isPlaying) { audioMeteoritoAnubis.Play(); }
        this.gameObject.transform.position = new Vector3(_horusPosition.transform.position.x, this.transform.position.y, _horusPosition.transform.position.z);

    }
}
