using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Weapons/WeaponInfo")]
public class WeaponInfo : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float bulletSpread;
    public int magazineSize;
    public float reloadTime;
    public float fireRate;
    public float weaponRange;
    public int startTotalAmmo;


}
