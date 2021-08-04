using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Inventory;
using UnityEngine.UI;

namespace DD.UI
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] Image[] equipmentImages = null;

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

            foreach (Image image in equipmentImages)
            {
                image.gameObject.SetActive(false);
            }

            for (int i = 0; i < currentEquipments.Count; i++)
            {
                equipmentImages[i].gameObject.SetActive(true);
                equipmentImages[i].sprite = currentEquipments[i].sprite;
            }
        }
    }
}

