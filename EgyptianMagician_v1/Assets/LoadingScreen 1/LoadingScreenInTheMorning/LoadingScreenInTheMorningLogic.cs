using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScreenInTheMorningLogic : MonoBehaviour
{
	public static LoadingScreenInTheMorningLogic instance;

	enum Estado
	{
		FadeANegro,
		DescargandoEscena,
		CargandoEscena,
		FadeAImagen,
		MostrandoImagen,
	};

	[SerializeField] CanvasGroup canvasGroup;

	Estado estado = Estado.MostrandoImagen;
	float alpha = 1f;
	string currentScene = "";
	string nextScene = "";

	AsyncOperation unloadOperation;
	AsyncOperation loadOperation;

	void Awake()
	{
		instance = this;
	}

    // Start is called before the first frame update
    void Start()
    {
        LoadScene("menu_principal");
    }

	public void LoadScene(string desiredScene)
	{
		nextScene = desiredScene;
	}

    // Update is called once per frame
    void Update()
    {
		switch(estado)
		{
			case Estado.MostrandoImagen:
				if (nextScene != "")
				{
					estado = Estado.FadeANegro;
				}
				break;
			case Estado.FadeANegro:
				alpha += Time.deltaTime;
				if (alpha > 1f)
				{
					alpha = 1f;
					if (currentScene != "")
					{
						unloadOperation = SceneManager.UnloadSceneAsync(currentScene);
					}
					estado = Estado.DescargandoEscena;
				}
				canvasGroup.alpha = alpha;
				break;
			case Estado.DescargandoEscena:
				if (unloadOperation != null) Debug.Log(unloadOperation.progress);

				if ((unloadOperation == null) || unloadOperation.isDone)
				{
					loadOperation = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
					if (loadOperation != null)
					{
						estado = Estado.CargandoEscena;
					}
				}
				break;
			case Estado.CargandoEscena:
				Debug.Log(loadOperation.progress);
				if (loadOperation.isDone)
				{
					estado = Estado.FadeAImagen;
					currentScene = nextScene;
					nextScene = "";
				}
				break;
			case Estado.FadeAImagen:
				alpha -= Time.deltaTime;
				if (alpha < 0f)
				{
					alpha = 0f;
					estado = Estado.MostrandoImagen;
				}
				canvasGroup.alpha = alpha;
				break;
		}
        
    }
}
