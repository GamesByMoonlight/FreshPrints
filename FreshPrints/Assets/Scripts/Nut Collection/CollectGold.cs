using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGold : MonoBehaviour {

    Coin[] coins;

	void Start()
    {
        coins = GetComponentsInChildren<Coin>();

    }


    public void CollectableAnimation(Vector3 location)
    {
        transform.position = location;

        StackCoins();

        foreach(Coin coin in coins)
        {
            coin.Flip();
        }
    }

    void StackCoins()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].Arrange(i);
        }
    }
}
