using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerRef : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    private void Update()
    {
        transform.position = new Vector2(playerTransform.position.x, transform.position.y);
    }
}
