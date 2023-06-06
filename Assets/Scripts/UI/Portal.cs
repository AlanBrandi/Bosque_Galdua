using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Portal : MonoBehaviour
{
    [SerializeField] private LevelChanger levelChanger;
    [SerializeField] private string levelName;
    [SerializeField] private bool isAutomatic;
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            Debug.Log("AAAAAAAA");
            if (!isAutomatic)
            {
                if (UserInput.instance.playerController.InGame.Debug_E.triggered)
                {
                    levelChanger.FadeToLevel(levelName);
                }
            }
            else
            {
                levelChanger.FadeToLevel(levelName);
            }
        }
    }
}