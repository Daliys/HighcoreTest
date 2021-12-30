using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StungunWeapon : WeaponBase
{
    [SerializeField] private NegativeEffects.NegativeEffect _negativeEffects;
    void Start()
    {
        _weaponType = WeaponType.stungun;
    }

    protected override void InitializeBullet(Vector3 position, string goalTag)
    {
        _currentAmmo--;
      
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation); // нужно через пул объектов, но на это нет времени )
        bulletClone.transform.LookAt(position);
        
        Vector3 spread = transform.forward;
        spread.x += Random.Range(-weaponInfo.bulletSpread, weaponInfo.bulletSpread);
        spread.y += Random.Range(weaponInfo.bulletSpread, weaponInfo.bulletSpread);
       
        bulletClone.GetComponent<Rigidbody>().velocity = spread * 85;
        bulletClone.GetComponent<Bullet>().Initialization(weaponInfo.damage,goalTag, _negativeEffects);
    }

    
}
