using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveAnubis : MonoBehaviour
{
    public Renderer dissolveShaderMaterial;
    public bool alo = false;
    public AnubisManager _am;
    // Start is called before the first frame update
    void Start()
    {
        dissolveShaderMaterial = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dissolveShaderMaterial.material.SetFloat("_DissolveAmount", ((1 - (_am.AnubisLife / _am.LifeFase3))));
    }
}
