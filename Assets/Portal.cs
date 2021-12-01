using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public UiManager UiManager;
    public LevelChanger levelChanger;
    public string levelName;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            UiManager.MyLoadScene("Tree");
            levelChanger.FadeToLevel(levelName);
        }
    }
}
