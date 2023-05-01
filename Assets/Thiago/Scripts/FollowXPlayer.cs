using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowXPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.0f;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        // cria uma nova posi��o para a c�mera com base na posi��o atual do jogador no eixo X e a posi��o atual da c�mera no eixo Y
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

        // suaviza o movimento da c�mera para evitar movimentos bruscos
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
