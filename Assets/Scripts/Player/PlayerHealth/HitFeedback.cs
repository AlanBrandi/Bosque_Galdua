using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFeedback : MonoBehaviour, IObserver
{
    [ColorUsage(true,true)]
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private AnimationCurve _flashSpeedCurve;

    private float _flashtime;
    private SpriteRenderer[] _spriteRenderers;
    private Material[] _material;

    private Coroutine _damageFlashCoroutine;

    private void Awake()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        Init();
    }
    private void Init()
    {
        _material = new Material[_spriteRenderers.Length];
        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _material[i] = _spriteRenderers[i].material;
        }
    }
    public void NotifyPlayerHit(int currentLives, float flashTimeTotal)
    {
        _flashtime = flashTimeTotal;
        CallDamageFlash();
    }

    public void CallDamageFlash()
    {
        _damageFlashCoroutine = StartCoroutine(DamageFlash());
    }
    private IEnumerator DamageFlash()
    {
        SetFlashColor();
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while(elapsedTime < _flashtime)
        {
            elapsedTime += Time.deltaTime;
            currentFlashAmount = Mathf.Lerp(1f, _flashSpeedCurve.Evaluate(elapsedTime), (elapsedTime / _flashtime));
            SetFlashAmount(currentFlashAmount);
            yield return null;
        }
    }
    private void SetFlashColor()
    {
        for (int i = 0; i < _material.Length; i++)
        {
            _material[i].SetColor("_FlashColor", _flashColor);
        }
    }
    private void SetFlashAmount(float amount)
    {
        for (int i = 0; i < _material.Length; i++)
        {
            _material[i].SetFloat("_FlashAmount", amount);
        }
    }

    void IObserver.NotifyPlayerHit(int currentLives)
    {
        throw new System.NotImplementedException();
    }
}
