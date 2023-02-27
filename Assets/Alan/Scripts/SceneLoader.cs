using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Scene previousScene;
    static SceneLoader instance;
    static AsyncOperation sceneLoadOperation;

    void Start()
    {
        previousScene = SceneManager.GetActiveScene();
    }

    public static SceneLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ScenePreloader").AddComponent<SceneLoader>();
                DontDestroyOnLoad(instance);
            }

            return instance;
        }
    }

    public void PreloadScene(string sceneName)
    {
        if (sceneLoadOperation == null)
        {
            sceneLoadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            sceneLoadOperation.allowSceneActivation = false;
        }
    }

    public void ActivateScene()
    {
        if (sceneLoadOperation != null)
        {
            sceneLoadOperation.allowSceneActivation = true;
            sceneLoadOperation = null;
            Invoke("CloseCurrentScene", 0.1f);
        }
    }
    public void CloseCurrentScene()
    {
        SceneManager.UnloadSceneAsync(previousScene);
    }
}