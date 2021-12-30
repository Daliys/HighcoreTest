using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{

    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private HelathText uiHealthText;

    void Start()
    {
        _currentHealth = enemyInfo.healthPoint;
    }
    
    protected override void LocalTakeDamage(float damage)
    {
        if (_currentHealth - damage <= 0)
        {
            _currentHealth = 0;
            Destroy(gameObject);
        }
        else
        {
            _currentHealth -= damage;
        }
        uiHealthText.SetHealthText(_currentHealth, enemyInfo.healthPoint);
    }

}
