using UnityEngine;
using DD.Combat;
using System.Collections;
using DD.Object;
using DD.Inventory;
using DD.FX;

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

            Equipment equipmentToPickUp;
            equipmentToPickUp = equipmentsToPickUp[Random.Range(0, equipmentsToPickUp.Length)];

            inventoryHandler.AddEquippment(equipmentToPickUp);

            myObject.EndActionWithThisObject();
            Destroy(myObject.gameObject);
        }
    }
}
