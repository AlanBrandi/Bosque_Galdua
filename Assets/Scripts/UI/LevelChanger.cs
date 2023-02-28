using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    Animator animator;
    string levelToLoad;
    Scene currentScene;
    UIManager UIManager;

    private void Start()
    {
        UIManager = GameObject.FindObjectOfType<UIManager>();
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
        currentScene = SceneManager.GetActiveScene();
        levelToLoad = currentScene.name;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
