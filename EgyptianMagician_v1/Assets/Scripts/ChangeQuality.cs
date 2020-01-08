using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeQuality : MonoBehaviour
{

    public void ChangeQualityFunction(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(qualityIndex);

    }
    public void OffButton(GameObject highlight) {
        highlight.SetActive(false);
    } 
}
