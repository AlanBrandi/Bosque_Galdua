using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugCodes : MonoBehaviour
{
    public string buffer;
    float maxTimeDif = 1;
    float timeDif;
    List<string> patterns = new List<string> { "ShiftH", "ShiftD", "ShiftK" };
    public float deltaTime;

    [SerializeField] TMP_Text fpsText;
    [SerializeField] GameObject FPS;
    GameObject player;
    PlayerHealth playerHealth;
    AudioSource audioSource;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PlayerManager");
        if (player == null)
        {
            Debug.LogWarning("PlayerManager not found. Turning DebugCodes off.");
            gameObject.SetActive(false);
        }
        else
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            audioSource = GetComponent<AudioSource>();
            timeDif = maxTimeDif;
        }
    }

    private void Update()
    {
        timeDif -= Time.deltaTime;
        if (timeDif <= 0)
        {
            buffer = "";
        }

        PlayerController.InGameActions input = UserInput.instance.playerController.InGame;
        switch (true)
        {
            case bool _ when input.Debug_Shift.triggered:
                AddToBuffer("Shift");
                break;
            case bool _ when input.Debug_H.triggered:
                AddToBuffer("H");
                break;
            case bool _ when input.Debug_D.triggered:
                AddToBuffer("D");
                break;
            case bool _ when input.Debug_K.triggered:
                AddToBuffer("K");
                break;
            case bool _ when input.Debug_F3.triggered:
                Debug.Log("F3");
                if (FPS != null)
                {
                    FPS.SetActive(!FPS.activeInHierarchy);
                }
                break;
        }
        if (UserInput.instance.playerController.InGame.Debug_Mouse3.triggered)
        {
            Vector3 v3 = Input.mousePosition;
            v3.z = 10f;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = 0f;
            player.transform.position = v3;
            /*Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            player.transform.position = pz;*/
        }
        if (FPS != null && FPS.activeInHierarchy && Time.timeScale > 0f)
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            fpsText.text = Mathf.Ceil(fps).ToString();
        }
        CheckPatterns();
    }

    void AddToBuffer(string c)
    {
        timeDif = maxTimeDif;
        buffer += c;
    }

    void CheckPatterns()
    {
        if (buffer.EndsWith(patterns[0]))
        {
            Debug.Log("+2 Health");
            audioSource.Play();
            playerHealth.AddLives(2);
            buffer = "";
        }
        if (buffer.EndsWith(patterns[1]))
        {
            Debug.Log("-3 Health");
            audioSource.Play();
            playerHealth.Hit(3);
            buffer = "";

        }
        if (buffer.EndsWith(patterns[2]))
        {
            Debug.Log("Killing all enemies");
            audioSource.Play();
            List<EnemiesScript> tmpEnemies = new List<EnemiesScript>();
            tmpEnemies.AddRange(GameObject.FindObjectsOfType<EnemiesScript>());
            foreach (EnemiesScript enemies in tmpEnemies)
            {
                enemies.TakeDamage(100);
            }
            buffer = "";
        }
    }
}
