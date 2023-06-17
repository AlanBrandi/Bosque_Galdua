using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    Animator animator;
    string levelToLoad;
    Scene currentScene;

    [SerializeField] private float timer;
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void RestartFade()
    {
        currentScene = SceneManager.GetActiveScene();
        PlayerHealth.Instance.SetLives(PlayerHealth.Instance.GetLives());
        levelToLoad = currentScene.name;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
    Invoke(nameof(StartFadeComplete), timer);
    }

    private void StartFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
