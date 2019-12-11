using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	public static LoadingScreen instance;	// Singleton




	[SerializeField]CanvasGroup fadeGroup;
	[SerializeField]string testSceneName;

	string currentSceneName = "";
	string sceneToLoadName = "";
	string nextSceneName = "";

	AsyncOperation unloadOperation;
	AsyncOperation loadOperation;

	[SerializeField]bool load;

	bool fadeInLoadingScreen;
	bool fadeOutLoadingScreen;
	float alphaFade = 1f;

	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		LoadScene("MainMenu");
	}

	public void LoadScene(string sceneName)
	{
		if (currentSceneName != "")
		{
			fadeInLoadingScreen = true;
			//unloadOperation = SceneManager.UnloadSceneAsync(currentSceneName);
			sceneToLoadName = sceneName;
		}
		else
		{
			nextSceneName = sceneName;
		}
	}

	void Update()
	{
		if (load)
		{
			load = false;
			LoadScene(testSceneName);
		}

		if (nextSceneName != "")
		{
			// Iniciar la carga de la escena
			loadOperation = SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Additive);
			currentSceneName = nextSceneName;

			// Reseteamos nombre para evitar
			// volver a entrar aquí
			nextSceneName = "";
		}

		if (loadOperation != null)
		{
			Debug.Log("Loading... " + loadOperation.progress);
			if (loadOperation.isDone)
			{
				// Ha terminado la carga
				loadOperation = null;
				fadeOutLoadingScreen = true;
			}
		}

		if (unloadOperation != null)
		{
			Debug.Log("Unloading... " + unloadOperation.progress);
			if (unloadOperation.isDone)
			{
				// Ha terminado la carga
				unloadOperation = null;
				nextSceneName = sceneToLoadName;
			}
		}

		if (fadeOutLoadingScreen)
		{
			alphaFade -= Time.deltaTime;
			if (alphaFade < 0f)
			{
				alphaFade = 0f;
				fadeOutLoadingScreen = false;
			}
			fadeGroup.alpha = alphaFade;
		}

		if (fadeInLoadingScreen)
		{
			alphaFade += Time.deltaTime;
			if (alphaFade > 1f)
			{
				alphaFade = 1f;
				fadeInLoadingScreen = false;
				unloadOperation = SceneManager.UnloadSceneAsync(currentSceneName);
			}
			fadeGroup.alpha = alphaFade;
		}
		
	}

}
