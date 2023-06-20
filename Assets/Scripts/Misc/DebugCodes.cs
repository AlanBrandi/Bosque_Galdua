using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class DebugCodes : MonoBehaviour
{
    public string buffer;
    float maxTimeDif = 1;
    float timeDif;
    List<string> patterns = new List<string> { "ShiftH", "ShiftD", "ShiftK" };
    public float deltaTime;

    [SerializeField] TMP_Text fpsText;
    [SerializeField] GameObject FPS;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] Toggle toggle;
    //[SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject debugUI;
    public int variableValue;
    GameObject player;
    PlayerHealth playerHealth;
    AudioSource audioSource;

    private bool dropdownValueChanged = false;

    private void Awake()
    {
        PopulateDropdown();
        SetDropdownValueBasedOnActiveScene();
        SetToggleBasedOnInvincibility();
        player = GameObject.FindGameObjectWithTag("PlayerManager");
        if (player == null)
        {
            Debug.LogWarning("PlayerManager not found. Turning DebugCodes off.");
            enabled = false;
        }
        else
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            audioSource = GetComponent<AudioSource>();
            timeDif = maxTimeDif;
        }
    }
    #region Initialization
    private void OnEnable()
    {
        UserInput.instance.playerController.InGame.Debug_Shift.performed += OnDebugShiftPerformed;
        UserInput.instance.playerController.InGame.Debug_H.performed += OnDebugHPerformed;
        UserInput.instance.playerController.InGame.Debug_D.performed += OnDebugDPerformed;
        UserInput.instance.playerController.InGame.Debug_K.performed += OnDebugKPerformed;
        UserInput.instance.playerController.InGame.Debug_F3.performed += OnDebugF3Performed;
        UserInput.instance.playerController.InGame.Debug_Mouse3.performed += OnDebugMouse3Performed;
    }

    private void OnDisable()
    {
        UserInput.instance.playerController.InGame.Debug_Shift.performed -= OnDebugShiftPerformed;
        UserInput.instance.playerController.InGame.Debug_H.performed -= OnDebugHPerformed;
        UserInput.instance.playerController.InGame.Debug_D.performed -= OnDebugDPerformed;
        UserInput.instance.playerController.InGame.Debug_K.performed -= OnDebugKPerformed;
        UserInput.instance.playerController.InGame.Debug_F3.performed -= OnDebugF3Performed;
        UserInput.instance.playerController.InGame.Debug_Mouse3.performed -= OnDebugMouse3Performed;
    }
    #endregion
    #region Bindings
    private void OnDebugShiftPerformed(InputAction.CallbackContext context)
    {
        AddToBuffer("Shift");
    }

    private void OnDebugHPerformed(InputAction.CallbackContext context)
    {
        AddToBuffer("H");
    }

    private void OnDebugDPerformed(InputAction.CallbackContext context)
    {
        AddToBuffer("D");
    }

    private void OnDebugKPerformed(InputAction.CallbackContext context)
    {
        AddToBuffer("K");
    }

    private void OnDebugF3Performed(InputAction.CallbackContext context)
    {
        Debug.Log("F3");
        if (FPS != null)
            FPS.SetActive(!FPS.activeSelf);
    }

    private void OnDebugMouse3Performed(InputAction.CallbackContext context)
    {
        /*Vector3 teleportPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        teleportPosition.z = 0;
        player.transform.position = teleportPosition;*/
    } // Doesn't work.
    #endregion

    private void Update()
    {
        timeDif -= Time.deltaTime;
        if (timeDif <= 0)
        {
            buffer = "";
        }

        if (FPS != null && FPS.activeSelf && Time.timeScale > 0f)
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
        foreach (string pattern in patterns)
        {
            if (buffer.EndsWith(pattern))
            {
                Debug.Log(pattern);
                audioSource.Play();

                if (pattern == "ShiftH")
                    playerHealth.AddLives(2);
                else if (pattern == "ShiftD")
                    playerHealth.Hit(2);
                else if (pattern == "ShiftK")
                {
                    EnemiesScript[] enemies = GameObject.FindObjectsOfType<EnemiesScript>();
                    foreach (EnemiesScript enemy in enemies)
                    {
                        enemy.TakeDamage(100);
                    }
                }
                buffer = "";
                break;
            }
        }
    }
    #region SceneChangerDropdown
    void PopulateDropdown()
    {
        dropdown.ClearOptions();

        int sceneCount = SceneManager.sceneCountInBuildSettings;
        string[] sceneNames = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            sceneNames[i] = sceneName;
        }

        dropdown.AddOptions(new List<string>(sceneNames));
    }

    void SetDropdownValueBasedOnActiveScene()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        int sceneIndex = dropdown.options.FindIndex(option => option.text == activeSceneName);
        if (sceneIndex >= 0 && !dropdownValueChanged)
        {
            dropdownValueChanged = true;
            dropdown.SetValueWithoutNotify(sceneIndex);
        }
    }

    public void LoadSelectedScene()
    {
        int sceneIndex = dropdown.value;
        string sceneName = dropdown.options[sceneIndex].text;
        SceneManager.LoadScene(sceneName);
    }
    #endregion

    public void SetToggleBasedOnInvincibility()
    {
        toggle.isOn = (PlayerHealth.Instance.invincible);
    }
    public void ToggleInvincibility()
    {
        PlayerHealth.Instance.invincible = !PlayerHealth.Instance.invincible;
    }

    public void SetSpeedBasedOnCurrentInt(string value)
    {
        Debug.Log(value);
        if (int.TryParse(value, out int newValue))
        {
            PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.Data.runMaxSpeed = newValue;
            }
            else
            {
                Debug.LogError("PlayerMovement component not found.");
            }
        }
    }

    public void ToggleDebug()
    {
        debugUI.SetActive(!debugUI.activeInHierarchy);
    }
}