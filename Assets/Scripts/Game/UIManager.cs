using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField] private GameObject deathPanel;
   [SerializeField]
   private TextMeshProUGUI _ammoTextMeshPro;
  

   public void ToggleDeathPanel()
   {
      deathPanel.SetActive(!deathPanel.activeSelf);
   }
   
   public void UpdateAmmo(int count)
   {
      _ammoTextMeshPro.text = "Ammo: " + count;
   }
}
