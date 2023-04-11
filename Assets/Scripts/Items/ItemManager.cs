using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public static ItemManager Instance;
    public int coins;
    #endregion

    #region Methods

    // *Item Manager explanation*
    // The idea is that the Item Manager to be a Singleton.
    // And within it we'll have the methods to manage the itens in the game.

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

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
    }
    #endregion
}
