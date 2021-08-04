using UnityEngine;
using DD.Combat;
using System.Collections;
using DD.Object;

namespace DD.Action
{
    [CreateAssetMenu(fileName = "PickUpItem", menuName = "DungeonDesigner/Action/PickUpItem", order = 0)]
    public class PickUpItem : Action
    {
        [SerializeField] 

        public override void Handle(ActionObject myObject)
        {

        }

        // IEnumerator HandleFX() 나중에 effect 처리
        // {
        //     yield return new WaitForSeconds(1f);
        //     EndAction();
        // }
    }
}
