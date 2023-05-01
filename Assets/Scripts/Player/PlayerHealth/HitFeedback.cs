using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitFeedback : MonoBehaviour, IObserver
{
    // Player Sprites.
    [Header("Player sprites")]
    [SerializeField] private SpriteRenderer _headSprite;
    [SerializeField] private SpriteRenderer _rightHandSprite;
    [SerializeField] private SpriteRenderer _leftHandSprite;
    [SerializeField] private SpriteRenderer _rightFootSprite;
    [SerializeField] private SpriteRenderer _leftFootSprite;
    [SerializeField] private SpriteRenderer _swordSprite;
    //Materials.
    [Header("Material")]
    [SerializeField] private Material _playerDefaultMaterial;
    [SerializeField] private Material _playerHitMaterial;

    [Header("Configuration")]
    [SerializeField] private float _invencibilityTimeFrame = 1;
    [SerializeField] private float _invencibilityTimerRemain;

    [Header("Visual/HUD/FX")]
    [SerializeField] private GameObject _hitBloodFX;
    [SerializeField] private Image _hitHUDPanel;

    //Function variables.
    private float timeRemain;
    private GameObject whereToAddEffect;

    private void Start()
    {
        timeRemain = _invencibilityTimeFrame;
        _hitHUDPanel.color = new Color(1, 1, 1, 0);
    }
    public void NotifyPlayerHit(int currentLives)
    {
        timeRemain = _invencibilityTimeFrame;
        switch (currentLives)
        {
            case 6:
                _hitHUDPanel.color = new Color(1, 1, 1, 0);
                break;
            case 5:
                _hitHUDPanel.color = new Color(0, 0, 0, .15f);
                break;
            case 4:
                _hitHUDPanel.color = new Color(1, 1, 1, 0.2f);
                break;
            case 3:
                _hitHUDPanel.color = new Color(1, 1, 1, 0.5f);
                break;
            case 2:
                _hitHUDPanel.color = new Color(1, 1, 1, 0.75f);
                break;
            case 1:
                _hitHUDPanel.color = new Color(1, 1, 1, 1);
                break;
        }
        ChangeAlphaPlayer();
        BlinkOn();
    }

    void BlinkOn()
    {
        _headSprite.material = _playerHitMaterial;
        _rightHandSprite.material = _playerHitMaterial;
        _leftHandSprite.material = _playerHitMaterial;
        _rightFootSprite.material = _playerHitMaterial;
        _leftFootSprite.material = _playerHitMaterial;
        _swordSprite.material = _playerHitMaterial;
        timeRemain -= .103f;
        Invoke("BlinkOff", (2 / timeRemain) * Time.fixedDeltaTime);
    }
    void BlinkOff()
    {
        if (timeRemain > 0)
        {
            _headSprite.material = _playerDefaultMaterial;
            _rightHandSprite.material = _playerDefaultMaterial;
            _leftHandSprite.material = _playerDefaultMaterial;
            _rightFootSprite.material = _playerDefaultMaterial;
            _leftFootSprite.material = _playerDefaultMaterial;
            _swordSprite.material = _playerDefaultMaterial;
            timeRemain -= .103f;
            Invoke("BlinkOn", (2 / timeRemain) * Time.fixedDeltaTime);
        }
        else
        {
            _headSprite.material = _playerDefaultMaterial;
            _rightHandSprite.material = _playerDefaultMaterial;
            _leftHandSprite.material = _playerDefaultMaterial;
            _rightFootSprite.material = _playerDefaultMaterial;
            _leftFootSprite.material = _playerDefaultMaterial;
            _swordSprite.material = _playerDefaultMaterial;
            ChangeToDefaultAlpha();
        }
    }
    void ChangeToDefaultAlpha()
    {
        _headSprite.color = new Color(1, 1, 1, 1);
        _rightHandSprite.color = new Color(1, 1, 1, 1);
        _leftHandSprite.color = new Color(1, 1, 1, 1);
        _rightFootSprite.color = new Color(1, 1, 1, 1);
        _leftFootSprite.color = new Color(1, 1, 1, 1);
        _swordSprite.color = new Color(1, 1, 1, 1);
    }
    void ChangeAlphaPlayer()
    {
        _headSprite.color = new Color(1, 1, 1, .7f);
        _rightHandSprite.color = new Color(1, 1, 1, .7f);
        _leftHandSprite.color = new Color(1, 1, 1, .7f);
        _rightFootSprite.color = new Color(1, 1, 1, .7f);
        _leftFootSprite.color = new Color(1, 1, 1, .7f);
        _swordSprite.color = new Color(1, 1, 1, .7f); ;
    }
}
