using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoading : MonoBehaviour
{
    public static SceneLoading instance;

    enum State {
        FadeBlack,
        DownloadingScene,
        LoadingScene,
        FadeImage,
        ShowImage
    };

    [SerializeField] CanvasGroup canvasGroup;

    State state = State.ShowImage;
    float alpha = 1f;
    string currentScene = "";
    string nextScene = "";

    AsyncOperation unloadOperation;
    AsyncOperation loadOperation;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        LoadScene("menu_principal");
    }

    public void LoadScene(string desiredScene) {
        nextScene = desiredScene;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {
            case State.ShowImage:
                if(nextScene != "") {
                    state = State.FadeBlack;
                }break;
            case State.FadeBlack:
                alpha += Time.deltaTime;
                if (alpha > 1f) {
                    alpha = 1f;
                    if(currentScene != "") {
                        unloadOperation = SceneManager.UnloadSceneAsync(currentScene);
                    }
                    state = State.DownloadingScene;
                }
                canvasGroup.alpha = alpha;
                break;
            case State.DownloadingScene:
                if((unloadOperation != null) || unloadOperation.isDone){
                    loadOperation = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
                    if(loadOperation != null) {
                        state = State.LoadingScene;
                    }
                }break;
            case State.LoadingScene:
                if (loadOperation.isDone) {
                    state = State.FadeImage;
                    currentScene = nextScene;
                    nextScene = "";
                }break;
            case State.FadeImage:
                alpha -= Time.deltaTime;
                if (alpha < 0f) {
                    alpha = 0f;
                    state = State.ShowImage;
                }
                canvasGroup.alpha = alpha;
                break;
          
        }
    }
}
