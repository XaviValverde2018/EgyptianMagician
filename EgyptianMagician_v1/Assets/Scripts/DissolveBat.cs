using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveBat : MonoBehaviour
{
    public Material[] dissolveShaderMaterial = new Material[2];
    public bool vidaEnemicBool = false;
    public EnemyManager _enemyManagerDissolve;
    public float DissolveValue;
    public float vidaenemic;
    // Start is called before the first frame update
    private void Awake() {

            // dissolveShaderMaterial.material.shader = Shader.Find("_DissolveAmount");
            dissolveShaderMaterial[0].SetFloat("_DissolveAmount", 0);
            dissolveShaderMaterial[1].SetFloat("_DissolveAmount", 0);
    }


    // Update is called once per frame
    void Update() {
        vidaenemic = _enemyManagerDissolve.vidaEnemics;
        ActiveDissolve();
        if (vidaEnemicBool) {
            dissolveShaderMaterial[0].SetFloat("_DissolveAmount", (DissolveValue += 0.7f * Time.deltaTime));
            dissolveShaderMaterial[1].SetFloat("_DissolveAmount", (DissolveValue += 0.7f * Time.deltaTime));

        }
    }
    void ActiveDissolve() {
        if (_enemyManagerDissolve.vidaEnemics <= 0) {
            vidaEnemicBool = true;
        }
    }
}
