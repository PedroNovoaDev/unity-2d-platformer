using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public int damage = 10;
    public HealthBase healthBase;
    public float timeToDestroy = 1.5f;

    [Header("Animation")]
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";
    #endregion

    #region Methods

// *Enemy base explanation*
// The ideia is to have a script to be reutilazable and manage the general behaviour of the enemys.
// Before applying any damage we check if the game object has a health base component.
// We add a Callback to kill the enemy.

private void Awake()
    {
        if (healthBase != null)
            healthBase.onKill += OnEnemyKill;
    }

    private void OnEnemyKill()
    {
        healthBase.onKill -= OnEnemyKill;
        EnemyDeathAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            PlayerAttackAnimation();
        }
    }

    private void PlayerAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void EnemyDeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
    #endregion
}
