using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugCodes : MonoBehaviour
{
    string buffer;
    float maxTimeDif = 1;
    float timeDif;
    List<string> patterns = new List<string> { "ShiftH" };
    GameData_SO gameData;

    public TMP_Text fpsText;
    public float deltaTime;
    GameObject FPS;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        timeDif = maxTimeDif;
        gameData = Resources.Load("PlayerLives") as GameData_SO;
        FPS = GameObject.Find("FPS");
        FPS.SetActive(false);
    }

    private void Update()
    {
        timeDif -= Time.deltaTime;
        if (timeDif <= 0)
        {
            buffer = "";
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                AddToBuffer("ShiftH");
            }
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            Debug.Log("F3");
            if (FPS != null && FPS.activeInHierarchy == false)
            {
                FPS.SetActive(true);
            }
            else if (FPS != null)
            {
                FPS.SetActive(false);
            }
        }
        if (FPS != null && FPS.activeInHierarchy == true)
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
            Debug.Log("+5 Health");
            audioSource.Play();
            gameData.lives += 5;
            buffer = "";
        }
    }
}
