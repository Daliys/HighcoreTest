using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PistolWeapon : WeaponBase
{
    private void Start()
    {
        _weaponType = WeaponType.pistol;
    }

    protected override void InitializeBullet(Vector3 position, string goalTag)
    {
        base.InitializeBullet(position, goalTag);
       
    }
}
