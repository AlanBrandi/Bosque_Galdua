using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameObject doorObject;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        doorObject = gameObject;
    }

    public void Open()
    {
        audioSource.Play();
        Invoke(nameof(DeleteGameObject), 1.5f);
    }

    void DeleteGameObject()
    {
        doorObject.SetActive(false);
    }
}
