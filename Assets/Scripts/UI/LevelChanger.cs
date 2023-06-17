using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public static LevelChanger Instance { get; private set; }

    Animator animator;
    string levelToLoad;
    [SerializeField] private float timer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel(string levelName)
    {
        Debug.Log("Jogma");
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void RestartFade()
    {
        PlayerHealth.Instance.SetLives(PlayerHealth.Instance.GetLives());
        levelToLoad = SceneManager.GetActiveScene().name;
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