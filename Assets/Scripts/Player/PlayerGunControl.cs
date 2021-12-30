using UnityEngine;
using UnityEngine.Serialization;

public class PlayerGunControl : MonoBehaviour
{
    
    [SerializeField] private WeaponBase []weapons;
    [FormerlySerializedAs("uiWeaponStats")] [SerializeField] private UI_Canvas uiCanvas;

    private WeaponBase currentWeapon;

    private void Start()
    {
        currentWeapon = weapons[0];
        uiCanvas.UpdateStats(currentWeapon);
    }

    void Update()
    {
        IsSwitchWeapon();
        IsFireAttack();
    }

    void IsFireAttack()
    {
        if (currentWeapon.GetWeaponType().Equals(WeaponBase.WeaponType.autoRifle))
        {
            if (Input.GetButton("Fire1"))
            {
                currentWeapon.Fire(GetFirePosition(), "Enemy");
                uiCanvas.UpdateStats(currentWeapon);
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                currentWeapon.Fire(GetFirePosition(), "Enemy");
                uiCanvas.UpdateStats(currentWeapon);
            }  
        }

        if (currentWeapon.IsReloading())
        {
            uiCanvas.UpdateInfoText("Reloading");
        }
        else
        { 
            uiCanvas.UpdateInfoText("");
            uiCanvas.UpdateStats(currentWeapon);
        }
    }

    Vector3 GetFirePosition()
    {
        Vector3 screenSpaceCenter = new Vector3(0.5f, 0.5f, 0);
        return Camera.main.ViewportToWorldPoint(screenSpaceCenter);
    }

    void IsSwitchWeapon()
    {
        if(Input.GetButtonDown("Weapon1"))
        {
            SwitchWeapon(0);
        }
        else if(Input.GetButtonDown("Weapon2"))
        {
            SwitchWeapon(1);
        }
        else if(Input.GetButtonDown("Weapon3"))
        {
            SwitchWeapon(2);
        } else if(Input.GetButtonDown("Weapon4"))
        {
            SwitchWeapon(3);
        }
    }

    void SwitchWeapon(int id)
    {
        currentWeapon = weapons[id];
        HideAllWeapons();
        currentWeapon.gameObject.SetActive(true);
        uiCanvas.UpdateStats(currentWeapon);
    }

    void HideAllWeapons()
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }
    
}
