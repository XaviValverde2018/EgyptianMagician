using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInTheMorning : MonoBehaviour
{
	public void PlayButton()
	{
		LoadingScreenInTheMorningLogic.instance.LoadScene("lvl1");
	}
}
