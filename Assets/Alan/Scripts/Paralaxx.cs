using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Camera player")]
    [SerializeField] private Camera cameraPlayer;

    [Header("Parallax config")]
    [SerializeField] private float parallaxSpeed;

    private float lenght;
    private float startPos;

    private void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float tmp = (cameraPlayer.transform.position.x * (1 - parallaxSpeed));
        float dist = (cameraPlayer.transform.position.x * parallaxSpeed);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(tmp > startPos + lenght)
        {
            startPos += lenght;
        }
        else if (tmp < startPos - lenght)
        {
            startPos -= lenght;
        }
    }
}
