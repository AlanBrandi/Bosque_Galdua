using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    Animator animator;
    string levelToLoad;
    Scene currentScene;
    UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>().GetComponent<UIManager>();
        currentScene = SceneManager.GetActiveScene();
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void RestartFade()
    {
        GameManager.Instance.SetLife(6);
        levelToLoad = currentScene.name;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
