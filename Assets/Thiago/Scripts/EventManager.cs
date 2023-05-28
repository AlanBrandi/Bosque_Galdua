using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManager>();

                if (instance == null)
                {
                    Debug.LogError("O objeto EventManager não está presente na cena.");
                }
            }

            return instance;
        }
    }

    public delegate void ActivateMonstrinho(GameObject obj, bool activate);
    public event ActivateMonstrinho ActivatedMonstrinho;


    public void ActivateMonstrinhoTrap(GameObject obj)
    {
        if (ActivatedMonstrinho != null)
        {
            ActivatedMonstrinho(obj, true);
        }
    }
}