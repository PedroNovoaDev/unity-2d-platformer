using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    #region Variables
    [Header("Variables")]
    public int coins;
    #endregion

    #region Methods

    // *Item Manager explanation*
    // The idea is that the Item Manager to be a Singleton.
    // And within it we'll have the methods to manage the itens in the game.

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UIInGameManager.UpdateCoinsText(coins.ToString());
    }
    #endregion
}
