using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region Variables
    [Header("Enemy variables")]
    public HealthBase healthBase;
    public int damage = 10;
    public float timeToDestroy = 1.5f;

    [Header("Enemy animation")]
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";
    #endregion

    #region Methods

    // *Enemy base explanation*
    // The ideia is to have a script to be reutilazable and manage the general behaviour of the enemys.


    private void Awake()
    {

        // In the Awake of the EnemyBase script we check if the game object has a HealthBase defined so we can add the onKill variable callback.

        if (healthBase != null)
            healthBase.onKill += OnEnemyKill;
    }

    private void OnEnemyKill()
    {

        // The OnEnemyKill is a callback function invoked in the HealthBase script to trigger the death animation and destruction of the enemy.

        healthBase.onKill -= OnEnemyKill;
        EnemyDeathAnimation();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Before applying any damage we check if the game object has a HealthBase component.
        // Only if trye we apply the damage and trigger the animation.

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
