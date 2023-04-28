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

    [Header("Enemy patrol")]
    public int UnitsToMove = 5;
    public float EnemySpeed = 30;
    private bool _moveRight = true;
    private float _startPos;
    private float _endPos;

    private BoxCollider2D _myBoxCollider2D;
    private Rigidbody2D _myRigidBody2D;
    #endregion

    #region Methods

    // *Enemy base explanation*
    // The ideia is to have a script to be reutilazable and manage the general behaviour of the enemys.


    private void Awake()
    {

        // In the Awake of the EnemyBase script we check if the game object has a HealthBase defined so we can add the onKill variable callback.
        // We also get the reference of the collider to deactivate it when the enemy die and the rigidbody to make the patrol of the enemy.

        if (healthBase != null)
            healthBase.onKill += OnEnemyKill;

        _myBoxCollider2D = GetComponent<BoxCollider2D>();
        _myRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
    }

    public void Update()
    {
        if (_moveRight)
        {
            _myRigidBody2D.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);
        }

        if (_myRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            _myRigidBody2D.AddForce(-Vector2.right * EnemySpeed * Time.deltaTime);
        }
        if (_myRigidBody2D.position.x <= _startPos)
            _moveRight = true;
    }

    private void OnEnemyKill()
    {

        // The OnEnemyKill is a callback function invoked in the HealthBase script to trigger the death animation and destruction of the enemy.

        healthBase.onKill -= OnEnemyKill;
        _myBoxCollider2D.enabled = false;
        EnemyDeathAnimation();
        AudioManager.Instance.PlayEnemyDeathSound();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Before applying any damage we check if the game object has a HealthBase component.
        // Only if true we apply the damage and trigger the animation.

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
