using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region Variables
    [Header("Health variables")]
    public int startLife = 10;
    public Action onKill;

    private int _currentLife;
    private bool _isDead = false;
    [SerializeField] private FlashColor _flashColor;
    #endregion

    #region Methods

    // *Health base explanation*
    // The ideia is to have a script to be reutilazable and manage the health state of the game object which is inserted.

    private void Awake()
    {
        Init();
        if (_flashColor == null)
            _flashColor = GetComponent<FlashColor>();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {

        // When the game object that has the script takes damage it will flash to give a feedback to the player.

        if (_isDead) return;

        _currentLife -= damage;

        if (_flashColor != null)
            _flashColor.Flash();

        if (_currentLife <= 0)
            Kill();
    }

    private void Kill()
    {
        _isDead = true;
        onKill.Invoke();
    }
    #endregion
}
