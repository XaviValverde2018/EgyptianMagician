﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadPlay : MonoBehaviour
{
   public void Play() {
        SceneManager.LoadScene("lvl1");
    }
}
