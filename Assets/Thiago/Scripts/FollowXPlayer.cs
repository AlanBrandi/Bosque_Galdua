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
        // cria uma nova posição para a câmera com base na posição atual do jogador no eixo X e a posição atual da câmera no eixo Y
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

        // suaviza o movimento da câmera para evitar movimentos bruscos
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
