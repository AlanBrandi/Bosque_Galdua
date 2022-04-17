using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    Animator animator;
    public string levelToLoad;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
