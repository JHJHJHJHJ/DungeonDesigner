using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Inventory;
using UnityEngine.UI;

namespace DD.UI
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] EquipmentDisplay[] equipDisplays = null;

        [SerializeField] GameObject player;
        InventoryHandler inventoryHandler;

        private void Awake() 
        {
            inventoryHandler = player.GetComponent<InventoryHandler>();
        }

        private void Start()
        {
            UpdateDisplay();
        }

        public void UpdateDisplay() // Event Handler에서 실행됨
        {
            List<Equipment> currentEquipments = inventoryHandler.GetCurrentEquippments();

            foreach (EquipmentDisplay equipDisplay in equipDisplays)
            {
                equipDisplay.SwitchImageObject(false);
            }

            for (int i = 0; i < currentEquipments.Count; i++)
            {
                equipDisplays[i].SwitchImageObject(true);
                equipDisplays[i].UpdateImage(currentEquipments[i].sprite);
            }
        }
    }
}

