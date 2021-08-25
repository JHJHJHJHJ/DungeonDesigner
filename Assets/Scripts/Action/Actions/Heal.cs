using UnityEngine;
using DD.Combat;
using System.Collections;
using DD.Object;
using DD.FX;

namespace DD.Action
{
    [CreateAssetMenu(fileName = "Heal", menuName = "DungeonDesigner/Action/Heal", order = 0)]
    public class Heal : Action
    {
        [SerializeField] float healAmount = 30f;

        public override void Handle(ActionObject myObject, GameObject myPlayer)
        {
            Health health = myPlayer.GetComponent<Health>();
            health.Heal(healAmount);

            myObject.EndActionWithThisObject();
            Destroy(myObject.gameObject);

            FXMessage.ShowMessage("체력을 모두 회복했다!", myObject.dungeonID);

            // health.StartCoroutine(HandleFX());
        }

        // IEnumerator HandleFX() 나중에 effect 처리
        // {
        //     yield return new WaitForSeconds(1f);
        // }
    }
}
