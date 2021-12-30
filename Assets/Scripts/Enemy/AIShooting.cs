using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooting : MonoBehaviour
{
    [SerializeField] private WeaponBase []weapons;
    
    private WeaponBase currentWeapon;
    private bool _isCanShoot;
    private bool _isAutoRifleAttack;
    private void Start()
    {
        currentWeapon = weapons[Random.Range(0,weapons.Length)];
        //currentWeapon = weapons[1];
        currentWeapon.gameObject.SetActive(true);
        _isCanShoot = true;
        _isAutoRifleAttack = false;
        
    }
    public void ShootingUpdate()
    {
        if(_isCanShoot) Shoot();               
    }

    private void Shoot()
    {
        if (currentWeapon.GetWeaponType().Equals(WeaponBase.WeaponType.autoRifle))
        {
            if (!_isAutoRifleAttack) StartCoroutine(AutoRifleAttack());
            else{ 
                transform.LookAt(GameManager.Instance.GetPlayer().transform.position);
                currentWeapon.Fire(GetShootingPosition(), "Player");
            }
        }
        else
        {
            transform.LookAt(GameManager.Instance.GetPlayer().transform.position);
            currentWeapon.Fire(GetShootingPosition(),"Player");
            StartCoroutine(ShootTimer());
        }
    }

    IEnumerator AutoRifleAttack()
    {
        _isAutoRifleAttack = true;
        yield return new WaitForSecondsRealtime(Random.Range(0.2f, 1f));
        _isAutoRifleAttack = false;
        StartCoroutine(ShootTimer());
    }

    IEnumerator ShootTimer()
    {
        _isCanShoot = false;
        yield return new WaitForSecondsRealtime(Random.Range(0.7f, 2));
        _isCanShoot = true;
    }


    private Vector3 GetShootingPosition()
    {
        Vector3 pos = GameManager.Instance.GetPlayer().transform.position;
        pos.y -= 0f;
        return pos;
    }
}
