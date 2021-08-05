using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DD.UI
{
    public class EquipmentDisplay : MonoBehaviour
    {
        [SerializeField] Image image;

        public void UpdateImage(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}

