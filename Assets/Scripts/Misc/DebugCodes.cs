using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugCodes : MonoBehaviour
{
    public string buffer;
    float maxTimeDif = 1;
    float timeDif;
    List<string> patterns = new List<string> { "ShiftH", "ShiftD", "ShiftK" };

    TMP_Text fpsText;
    public float deltaTime;
    GameObject FPS;
    GameObject player;

    AudioSource audioSource;

    private void Awake()
    {
        fpsText = GameObject.Find("FPS").GetComponent<TMP_Text>();
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        timeDif = maxTimeDif;
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
            AddToBuffer("Shift");
            if (Input.GetKeyDown(KeyCode.H))
            {
                AddToBuffer("H");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                AddToBuffer("D");
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                AddToBuffer("K");
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
        else if (Input.GetMouseButton(2))
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
            Debug.Log("+2 Health");
            audioSource.Play();
            GameManager.Instance.IncreaseLife(2);
            buffer = "";
        }
        if (buffer.EndsWith(patterns[1]))
        {
            Debug.Log("-3 Health");
            audioSource.Play();
            GameManager.Instance.DecreaseLife(3);
            buffer = "";
            
        }
        if (buffer.EndsWith(patterns[2]))
        {
            Debug.Log("Killing all enemies");
            audioSource.Play();
            List<EnemiesScript> tmpEnemies= new List<EnemiesScript>();
            tmpEnemies.AddRange(GameObject.FindObjectsOfType<EnemiesScript>());
            foreach (EnemiesScript enemies in tmpEnemies)
            {
                enemies.TakeDamage(100);
            }
            buffer = "";
        }
    }
}
