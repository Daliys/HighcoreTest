using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class HealthManager : MonoBehaviour, ITakeDamage
{
    protected float _currentHealth;
    protected List<NegativeEffects> _negativeEffectsList;
    
    void Awake()
    {
        _negativeEffectsList = new List<NegativeEffects>();
    }
    
    private void Update()
    {
        if (_negativeEffectsList.Count != 0)
        {
            foreach (var item in _negativeEffectsList)
            {
                item.UpdateNegativeEffect(this);
                if (item.HasFinishEffected())
                {
                    _negativeEffectsList.Remove(item);
                    return;
                }
                
            }
        }
    }

    public void TakeDamage(float damage)
    {
        LocalTakeDamage(damage);
    }

    

    public void TakeDamage(float damage, NegativeEffects.NegativeEffect negativeEffects)
    {
        LocalTakeDamage(damage);
        NegativeEffects effect = negativeEffects == NegativeEffects.NegativeEffect.lightning ? new LightningNegativeEffect() : null;
        _negativeEffectsList.Add(effect);
    }

    protected abstract void LocalTakeDamage(float damage);
}
