using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private bool isAutomatic;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Activating portal.");
            if (isAutomatic || UserInput.instance.playerController.InGame.Interact.triggered)
            {
                LevelChanger.Instance.FadeToLevel(levelName);
                gameObject.SetActive(false);
            }
        }
    }
}