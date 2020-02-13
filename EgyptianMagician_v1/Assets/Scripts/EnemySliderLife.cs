using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySliderLife : MonoBehaviour
{
    //This code is in Enemy
    //public float _enemySliderLife;
    public float maxLife;
    public GameObject SliderCanvas;
    public EnemyManager _enemyManager;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        //_enemySliderLife = _enemyManager.vidaEnemics;
        maxLife = _enemyManager.vidaEnemics; 
        slider.value = CalculateLife();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateLife();
        if(_enemyManager.vidaEnemics < maxLife) {
            SliderCanvas.SetActive(true);
        }
    }
    float CalculateLife() {
        return _enemyManager.vidaEnemics / maxLife;
    }

}
