using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    float shakeTimeRemaining;
    float shakePower;
    float shakeFadeTime;
    float shakeRotation;
    public float rotationMultiplier = 7f;


    private void Update()
    {
        if (UserInput.instance.playerController.InGame.Debug_K.triggered)
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

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
    }
    public void startShake(float lenght, float power)
    {
        shakeTimeRemaining = lenght;
        shakePower = power;

        shakeFadeTime = power / lenght;

        shakeRotation = power * rotationMultiplier;
        //Debug.Log("Shake");
    }
}
