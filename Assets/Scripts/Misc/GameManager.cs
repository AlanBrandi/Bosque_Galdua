using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameManager = new GameObject("GameManager");
                gameManager.AddComponent<GameManager>();
            }
            return instance;
        }
    }
    [HideInInspector] public GameData_SO playerLives;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerLives = Resources.Load("PlayerLives") as GameData_SO;
        DontDestroyOnLoad(gameObject);
    }
    public void SetLife(int i)
    {
        UIManager uimanager;
        uimanager = GameObject.FindObjectOfType<UIManager>();
        playerLives.lives = i;
        if (uimanager != null)
        {
            uimanager.SetLife(i);
        }
    }

    public void IncreaseLife(int i)
    {
        UIManager uimanager;
        uimanager = GameObject.FindObjectOfType<UIManager>();
        playerLives.lives += i;
        uimanager.IncreaseLife(i);
    }

    public void DecreaseLife(int i)
    {
        UIManager uimanager;
        uimanager = GameObject.FindObjectOfType<UIManager>();
        playerLives.lives -= i;
        uimanager.DecreaseLife(i);
    }

    
    #endregion
}
