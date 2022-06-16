using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
   public float shakeTimeRemaining;
    public float shakePower;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            startShake(.5f, 1f);
        }
    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;
            transform.position += new Vector3(xAmount, yAmount, 0f);
        }
    }
    public void startShake(float lenght, float power)
    {
        shakeTimeRemaining = lenght;
        shakePower = power;
    }
}
