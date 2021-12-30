using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningNegativeEffect : NegativeEffects
{
    private void Start()
    {
        currentNegativeEffect = NegativeEffect.lightning;
    }

    public override void UpdateNegativeEffect(HealthManager healthManager)
    {
        if (_isAvailableToEffects)
        {
            ((ITakeDamage)healthManager).TakeDamage(damagePerSecond);
            healthManager.StartCoroutine(UpdateEffect());
          
        }
    }

    protected override IEnumerator UpdateEffect()
    {     
        _isAvailableToEffects = false;
        yield return new WaitForSecondsRealtime(1f);
        timeDuration--;
        _isAvailableToEffects = true;
        if (timeDuration <= 0) _hasFinishEffected = true;
    }
}
