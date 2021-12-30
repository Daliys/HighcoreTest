using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class UI_Canvas : MonoBehaviour
{
   [SerializeField] private Text weaponName;
   [SerializeField] private Text currentAmmo;
   [SerializeField] private Text remainsAmmo;
   [SerializeField] private Text infoText;
   [SerializeField] private Text healthText;
   [SerializeField] private GameObject losePanel;

   public void UpdateStats(WeaponBase weapon)
   {
      weaponName.text = weapon.GetWeaponName();
      currentAmmo.text = weapon.GetCurrentAmmo().ToString();
      remainsAmmo.text = weapon.GetTotalAmmo().ToString();
   }

   public void UpdateInfoText(string info)
   {
      infoText.text = info;
   }

   public void SetHealthText(float health, float maxHealth)
   {
      healthText.text = health.ToString() + " \\ " + maxHealth.ToString();
   }

   public void ShowLosePanel()
   {
      losePanel.SetActive(true);
   }
   
}
