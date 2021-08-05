using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.PlayData
{
    public class Resource : MonoBehaviour
    {
        // Global
        [SerializeField] int coin = 0;

        public int GetCurrentCoin()
        {
            return coin;
        }

        public void AddCoin(int amount)
        {
            coin += amount;
        }

        public void UseCoin(int amount)
        {
            coin = Mathf.Max(coin - amount, 0);
        }
    }

}

