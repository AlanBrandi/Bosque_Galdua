using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOn : MonoBehaviour
{
    [SerializeField] GameObject openingTrigger;

    private void Start()
    {
        openingTrigger.SetActive(true);
    }
}
