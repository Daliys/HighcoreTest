using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Shotgun : WeaponBase
{

    private void Start()
    {
        _weaponType = WeaponType.shotgun;
    }

    protected override void InitializeBullet(Vector3 position, string goalTag)
    {
        _currentAmmo--;

        Vector3 spread = transform.forward;
        spread.x += Random.Range(-weaponInfo.bulletSpread, weaponInfo.bulletSpread);
        spread.y += Random.Range(weaponInfo.bulletSpread, weaponInfo.bulletSpread);

        for (int i = 0; i < 2; i++)
        {
            GameObject bulletClone = (GameObject) Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.transform.LookAt(position);

            Vector3 speredPos = bulletClone.transform.position;
            speredPos.x += (float) Math.Sign(Math.Pow(-1, (i + 1))) * 0.5f;
            bulletClone.transform.position = speredPos;

            bulletClone.GetComponent<Rigidbody>().velocity = spread * 85;
            bulletClone.GetComponent<Bullet>().Initialization(weaponInfo.damage, goalTag);
        }
    }
}
