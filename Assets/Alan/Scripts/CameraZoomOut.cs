using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomOut : MonoBehaviour
{
    [SerializeField] float startingFOV = 40f; // FOV inicial da câmera
    [SerializeField] float maxFOV = 50f; // FOV máximo que a câmera pode atingir
    [SerializeField] float increaseRate = 1f; // Taxa de aumento do FOV
    [SerializeField] float increaseInterval = 0.1f; // Intervalo de tempo entre cada aumento de FOV

    [SerializeField] CinemachineVirtualCamera camera;

    void Start()
    {
        StartCoroutine(IncreaseFOV());
    }

    IEnumerator IncreaseFOV()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseInterval);
            camera.m_Lens.FieldOfView += increaseRate;
            camera.m_Lens.FieldOfView = Mathf.Clamp(camera.m_Lens.FieldOfView, startingFOV, maxFOV);
        }
    }
}
