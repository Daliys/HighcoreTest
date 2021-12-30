using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerHealthManager : HealthManager
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private UI_Canvas uiCanvas;

    void Start()
    {
        _currentHealth = playerInfo.healthPoint;
        uiCanvas.SetHealthText(_currentHealth, playerInfo.healthPoint);
    }

    protected override void LocalTakeDamage(float damage)
    {
        if (_currentHealth - damage <= 0)
        {
            _currentHealth = 0;
            uiCanvas.ShowLosePanel();
            GameManager.Instance.StopGame(); 
        }
        else
        {
            _currentHealth -= damage;
        }
        uiCanvas.SetHealthText(_currentHealth, playerInfo.healthPoint);
    }
}
