using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class WeaponBase : MonoBehaviour
{

    [SerializeField] protected WeaponInfo weaponInfo;
    [SerializeField] protected GameObject bullet;

    public enum WeaponType
    {
        pistol, autoRifle, shotgun, stungun 
    }

    protected WeaponType _weaponType;
    
    protected int _currentAmmo;
    protected int _totalAmmo;

    protected bool _isReloading;
    protected bool _isCooldown;

    private void Awake()
    {
        _currentAmmo = weaponInfo.magazineSize;
        _totalAmmo = weaponInfo.startTotalAmmo;
        _isReloading = false;
        _isCooldown = false;
    }


    public void Fire(Vector3 position, string goalTag)
    {
        if (!_isReloading && !_isCooldown)
        {
            if (IsMagazineEmpty()) {
                Reloading();
                return;
            }
            else
            {
                InitializeBullet(position,goalTag);
                StartCoroutine(CooldownTimer());
            }
        }
      
    }
    
    protected virtual void InitializeBullet(Vector3 position, string goalTag)
    {
        _currentAmmo--;
      
        GameObject bulletClone = Instantiate(bullet, transform.position, transform.rotation); // нужно через пул объектов, но на это нет времени )
        bulletClone.transform.LookAt(position);
        
        Vector3 spread = transform.forward;
        spread.x += Random.Range(-weaponInfo.bulletSpread, weaponInfo.bulletSpread);
        spread.y += Random.Range(weaponInfo.bulletSpread, weaponInfo.bulletSpread);
       
        bulletClone.GetComponent<Rigidbody>().velocity = spread * 85;
        bulletClone.GetComponent<Bullet>().Initialization(weaponInfo.damage,goalTag);
    }

    bool IsMagazineEmpty()
    {
        return _currentAmmo <= 0;
    }

    void Reloading()
    {
        if (_totalAmmo > 0)
        {
            StartCoroutine(ReloadingCoroutine());
        }
      
    }

    IEnumerator ReloadingCoroutine()
    {
        _isReloading = true;
        yield return new WaitForSecondsRealtime(weaponInfo.reloadTime);
        _isReloading = false;

        if (_totalAmmo >= weaponInfo.magazineSize)
        {
            _currentAmmo = weaponInfo.magazineSize;
            _totalAmmo -= weaponInfo.magazineSize;
        }
        else
        {
            _currentAmmo = _totalAmmo;
            _totalAmmo = 0;
        }

    }

    IEnumerator CooldownTimer()
    {
        _isCooldown = true;
        yield return new WaitForSecondsRealtime(1f/weaponInfo.fireRate);
        _isCooldown = false;
        
    }

    private void OnEnable()
    {
        _isReloading = false;
        _isCooldown = false;
    }


    public bool IsReloading()
    {
        return _isReloading;
    }

    public string GetWeaponName()
    {
        return weaponInfo.weaponName;
    }

    public int GetCurrentAmmo()
    {
        return _currentAmmo;
    }
    public int GetTotalAmmo()
    {
        return _totalAmmo;
    }

    public WeaponType GetWeaponType()
    {
        return _weaponType;
    }
}
 
