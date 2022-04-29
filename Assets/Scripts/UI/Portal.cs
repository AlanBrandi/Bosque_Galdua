using UnityEngine;

public class Portal : MonoBehaviour
{
    LevelChanger levelChanger;
    public string levelName;

    private void Start()
    {
        levelChanger = GameObject.FindObjectOfType<LevelChanger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelChanger.FadeToLevel(levelName);
        }
    }
}