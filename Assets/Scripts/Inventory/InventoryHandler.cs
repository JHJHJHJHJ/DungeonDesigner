using UnityEngine;
using System.Collections.Generic;
using DD.Core;
using DD.FX;

namespace DD.Inventory
{
    [RequireComponent(typeof(DDEventListener))]
    public class InventoryHandler : MonoBehaviour
    {
        [SerializeField] int limitCount = 3;
        [SerializeField] List<Equipment> equipments = new List<Equipment>();
        [SerializeField] DDEvent equipChanged;
        EquipStats wholeEquipStats;

        private void Awake() 
        {
            wholeEquipStats = new EquipStats();
            wholeEquipStats.Initialize();    
        }

        public void AddEquippment(Equipment equipmentToAdd)
        {
            if(equipments.Count < limitCount)
            {
                equipments.Add(equipmentToAdd);
                UpdqteWholeEquipStats();
                equipChanged.Occurred(this.gameObject);

                // FindObjectOfType<FXMessage>().Show(equipmentToAdd.myName + "을(를) 얻었다!" + "\n" + equipmentToAdd.description);
            }
            else
            {
                // FindObjectOfType<FXMessage>().Show("인벤토리가 가득 찼습니다.");
            }
        }

        public List<Equipment> GetCurrentEquippments() { return equipments; }

        public float GetInventoryDamage() { return wholeEquipStats.damageUP; }

        public float GetInventoryAttackSpeed() { return wholeEquipStats.attackSpeedUP; }

        public float GetInventoryArmor() { return wholeEquipStats.armorUP; }

        public float GetInventoryMoveSpeed() { return wholeEquipStats.moveSpeedUP; }

        public float GetInventoryMaxHealth() { return wholeEquipStats.maxHealthUP; }

        void UpdqteWholeEquipStats()
        {
            wholeEquipStats.Initialize();

            foreach (Equipment equipment in equipments)
            {
                wholeEquipStats.damageUP += equipment.equipStats.damageUP;
                wholeEquipStats.attackSpeedUP += equipment.equipStats.attackSpeedUP;
                wholeEquipStats.armorUP += equipment.equipStats.armorUP;
                wholeEquipStats.moveSpeedUP += equipment.equipStats.moveSpeedUP;
                wholeEquipStats.maxHealthUP += equipment.equipStats.maxHealthUP;
            }
        }
    }
}
