using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    #region Variables
    [Header("ItemManager variables")]
    public SOInt coins;
    #endregion

    #region Methods

    // *ItemManager explanation*
    // The idea is that the Item Manager to be a Singleton.
    // And within it we'll have the methods to manage the itens in the game.

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {

        // In the add coins method we add the coins collected by the player.
        // But in order to make variants of coins and set a initial amount of 1 in the parameter but leaving the option to receive another parameter value if needed.

        coins.value += amount;
    }
    #endregion
}
