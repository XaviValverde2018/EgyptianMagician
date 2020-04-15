using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSliderLife : MonoBehaviour {
    //This code is in Enemy
    //public float _enemySliderLife;
    public float maxLife;
    public GameObject SliderCanvas;
    public PlayerController _playerController;
    public Slider slider;
    public Image _colorImageFillSlider;
    public float oldPlayerLife;
    public Animator _animBloodHorus;
    // Start is called before the first frame update
    void Start() {
        _animBloodHorus.SetBool("BloodHorusBool", false);
        oldPlayerLife = _playerController.lifePlayer;
        //_enemySliderLife = _enemyManager.vidaEnemics;
        maxLife = _playerController.lifePlayer;
        slider.value = CalculateLife();

    }

    // Update is called once per frame
    void Update() {
        StartCoroutine(ChangePlayerLife());
        slider.value = CalculateLife();
        if (_playerController.lifePlayer < maxLife) {
            SliderCanvas.SetActive(true);
        }
        if ((_playerController.lifePlayer / maxLife) < 0.5f && (_playerController.lifePlayer / maxLife) >= 0.25f) {//groc
            _colorImageFillSlider.color = new Color(1, 0.92f, 0.016f, 1);
        }
        if ((_playerController.lifePlayer / maxLife) < 0.25f) {
            _colorImageFillSlider.color = new Color(1, 0, 0, 1);
        }
        if ((_playerController.lifePlayer / maxLife) >= 0.5f) {
            _colorImageFillSlider.color = new Color(0, 1, 0, 1);
        }
        
    }
    float CalculateLife() {
        return _playerController.lifePlayer / maxLife;
    }
    IEnumerator ChangePlayerLife() {
        if(_playerController.lifePlayer != oldPlayerLife) {
            Debug.Log("dolor");
            _animBloodHorus.SetBool("BloodHorusBool", true);
            yield return new WaitForSeconds(0.36f);
            oldPlayerLife = _playerController.lifePlayer;
            _animBloodHorus.SetBool("BloodHorusBool", false);

        }
    }

}

