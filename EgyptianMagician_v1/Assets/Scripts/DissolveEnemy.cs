using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEnemy : MonoBehaviour
{
    public Renderer dissolveShaderMaterial;
    public bool alo = false;
    public EnemyManager _enemyManagerDissolve;
    public float papa;
    public float vidaenemic;
    // Start is called before the first frame update
    void Start()
    {
        dissolveShaderMaterial = GetComponent<Renderer>();
       // dissolveShaderMaterial.material.shader = Shader.Find("_DissolveAmount");
    }

    // Update is called once per frame
    void Update()
    {
        vidaenemic = _enemyManagerDissolve.vidaEnemics;
        ActiveDissolve();
        if (alo) {
            dissolveShaderMaterial.material.SetFloat("_DissolveAmount", (papa += 0.8f*Time.deltaTime));
            
        }
    }
    void ActiveDissolve() {
        if(_enemyManagerDissolve.vidaEnemics <= 0) {
            alo = true;
        }
    }
}
