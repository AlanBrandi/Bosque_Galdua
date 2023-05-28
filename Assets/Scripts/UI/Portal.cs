using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Portal : MonoBehaviour
{
    LevelChanger levelChanger;
    public string levelName;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && UserInput.instance.playerController.InGame.Debug_E.triggered)
        {            
                
                levelChanger.FadeToLevel(levelName);
            

        }
    }
}