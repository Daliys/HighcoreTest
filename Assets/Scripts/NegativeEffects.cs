
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public abstract class NegativeEffects
{
    protected bool _isAvailableToEffects = true;
    protected bool _hasFinishEffected = false;

    [SerializeField] protected float timeDuration = 10;
    [SerializeField] protected float damagePerSecond = 5;

    public enum NegativeEffect
    {
        Null,lightning
    }

    public NegativeEffect currentNegativeEffect;
    
    public abstract void UpdateNegativeEffect(HealthManager healthManager);

    protected abstract IEnumerator UpdateEffect();

    public bool HasFinishEffected()
    {
        return _hasFinishEffected;
    }

}
