using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData : MonoBehaviour
{
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
