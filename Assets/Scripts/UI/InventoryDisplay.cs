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

        GameObject player;
        InventoryHandler inventoryHandler;

        private void Awake() 
        {
            player = GameObject.FindGameObjectWithTag("Player");
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
                equipDisplay.gameObject.SetActive(false);
            }

            for (int i = 0; i < currentEquipments.Count; i++)
            {
                equipDisplays[i].gameObject.SetActive(true);
                equipDisplays[i].UpdateImage(currentEquipments[i].sprite);
            }
        }
    }
}

