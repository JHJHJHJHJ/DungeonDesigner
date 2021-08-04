using UnityEngine;
using DD.Combat;
using System.Collections;
using DD.Object;
using DD.Inventory;

namespace DD.Action
{
    [CreateAssetMenu(fileName = "PickUpItem", menuName = "DungeonDesigner/Action/PickUpItem", order = 0)]
    public class PickUpItem : Action
    {
        [SerializeField] Equipment[] equipmentsToPickUp = null;

        public override void Handle(ActionObject myObject)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            InventoryHandler inventoryHandler = player.GetComponent<InventoryHandler>();

            if (inventoryHandler.GetCurrentEquippments().Count < 4)
            {
                Equipment equipmentToPickUp;
                while (true)
                {
                    equipmentToPickUp = equipmentsToPickUp[Random.Range(0, equipmentsToPickUp.Length)];

                    bool isDuplicate = false;
                    foreach (Equipment equipment in inventoryHandler.GetCurrentEquippments())
                    {
                        if (equipmentToPickUp == equipment) isDuplicate = true;
                    }

                    if (!isDuplicate) break;
                }

                inventoryHandler.AddEquippment(equipmentToPickUp);
            }
            else
            {
                //Do NOTHING
            }

            myObject.EndActionWithThisObject();
            Destroy(myObject.gameObject);
        }
    }
}
