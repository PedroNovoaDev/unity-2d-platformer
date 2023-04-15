using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    #region Variables
    [Header("Player prefab")]
    public GameObject playerPrefab;

    [Header("Player Starting point")]
    public Transform startPoint;

    [Header("Player Spawn Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    [Header("Enemies list")]
    public List<GameObject> enemies;

    private GameObject _currentPlayer;
    #endregion

    #region Methods

    // *GameManager explanation*
    // We use the GameManager to control the state of the game.

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {

        // At the start of the GameManager script we'll spawn the player in the starting point with its prefab and a little animation.

        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
    }
    #endregion
}
