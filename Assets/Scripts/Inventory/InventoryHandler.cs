using UnityEngine;
using System.Collections.Generic;
using DD.Core;

namespace DD.Inventory
{
    public class InventoryHandler : MonoBehaviour
    {
        [SerializeField] List<Equipment> equipments = new List<Equipment>();
        EquipStats wholeEquipStats;

        private void Start() 
        {
            wholeEquipStats = new EquipStats();
            wholeEquipStats.Initialize();    
        }

        public void AddEquippment(Equipment equipmentToAdd)
        {
            equipments.Add(equipmentToAdd);
            UpdqteWholeEquipStats();
        }

        public List<Equipment> GetEquippments()
        {
            return equipments;
        }

        public float GetInventoryDamage()
        {
            return wholeEquipStats.damage;
        }

        public float GetInventoryAttackSpeed()
        {
            return wholeEquipStats.attackSpeed;
        }

        public float GetInventoryArmor()
        {
            return wholeEquipStats.armor;
        }

        public float GetInventorymoveSpeed()
        {
            return wholeEquipStats.moveSpeed;
        }

        void UpdqteWholeEquipStats()
        {
            wholeEquipStats.Initialize();

            foreach (Equipment equipment in equipments)
            {
                wholeEquipStats.damage += equipment.equipStats.damage;
                wholeEquipStats.attackSpeed += equipment.equipStats.attackSpeed;
                wholeEquipStats.armor += equipment.equipStats.armor;
                wholeEquipStats.moveSpeed += equipment.equipStats.moveSpeed;
            }
        }
    }
}
