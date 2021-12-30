using System;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;
    private string tag;
    private NegativeEffects.NegativeEffect _negativeEffects;
    public void Initialization(float damage, String goalTag)
    {
        this.damage = damage;
        tag = goalTag;
        Destroy(gameObject, 5);
        _negativeEffects = NegativeEffects.NegativeEffect.Null;
    }
    
    public void Initialization(float damage, String goalTag, NegativeEffects.NegativeEffect negativeEffects)
    {
        this.damage = damage;
        tag = goalTag;
        Destroy(gameObject, 5);
        _negativeEffects = negativeEffects;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals(tag)){
            if(_negativeEffects.Equals(NegativeEffects.NegativeEffect.Null)) other.transform.GetComponent<ITakeDamage>().TakeDamage(damage);
            else other.transform.GetComponent<ITakeDamage>().TakeDamage(damage, _negativeEffects);
            
            Destroy(gameObject);
        }
    }
}
