using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCloser : MonoBehaviour
{
    public string sceneName;

    public void CloseScene()
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}