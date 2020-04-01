using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnubisSliderLife : MonoBehaviour
{
    public float anubisMaxLife;
    public GameObject SliderCanvas;
    public Slider slider;
    public AnubisManager _anubisManager;
    public Image _colorImageFillSlider;


    // Start is called before the first frame update
    void Start()
    {
        anubisMaxLife = _anubisManager.AnubisLife;
        slider.value = CalculateAnubisLife();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateAnubisLife();

        // si te menys del 50% color GROC
        if((_anubisManager.AnubisLife/anubisMaxLife)<0.5f && (_anubisManager.AnubisLife / anubisMaxLife) >= 0.25f) {
            _colorImageFillSlider.color = new Color(1, 0.92f, 0.016f, 1);
            //invocacio de enemics cada firerate
        }

        // si te menys del 25% color VERMELL
        if((_anubisManager.AnubisLife / anubisMaxLife) < 0.25f){
            //augment escala, daño, velocitat, area, i possible teleport
            _colorImageFillSlider.color = new Color(1, 0, 0, 1);
        }

        // si te més del 50% color VERD
        if((_anubisManager.AnubisLife / anubisMaxLife) >= 0.5f) {
            //incovacio de meteoritos cada firerate
            _colorImageFillSlider.color = new Color(0, 1, 0, 1);
        }


    }
    float CalculateAnubisLife() {
        return _anubisManager.AnubisLife / anubisMaxLife;
    }
}
