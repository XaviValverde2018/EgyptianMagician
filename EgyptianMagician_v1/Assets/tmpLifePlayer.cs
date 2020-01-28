using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tmpLifePlayer : MonoBehaviour
{
    [Header("TMP")]
    public TextMeshProUGUI textMeshLifePlayer;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        textMeshLifePlayer = GetComponent<TextMeshProUGUI>();
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshLifePlayer.text = score.ToString();
        score++;
    }
}
