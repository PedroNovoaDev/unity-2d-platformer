using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public int startLife = 10;
    public bool destroyOnKill = false;
    public float delayToKill = 0f;

    private int _currentLife;
    private bool _isDead = false;
    #endregion

    #region Methods

    // *Health base explanation*
    // The ideia is to have a script to be reutilazable and manage the health state of the game object.

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {

        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
            Kill();
    }

    private void Kill()
    {
        _isDead = true;

        if (destroyOnKill)
            Destroy(gameObject, delayToKill);
    }
    #endregion
}
