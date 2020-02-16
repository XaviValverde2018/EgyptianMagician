﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentMeteoritoNull : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = null;
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CountDown() {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
