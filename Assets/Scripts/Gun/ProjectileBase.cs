using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{

    #region Variables
    [Header("Variables")]
    public Vector3 direction;
    public float timeToDestroy = 1f;
    public float side = 1;
    public int damageAmount = 1;
    #endregion

    #region Methods

    // *Projectile base explanation*
    // The ideia is to have a script to be reutilazable and manage the projectile state of the game object.
    // The projectile game object need to be destroyed so it doesn't. polute the scene, so we destroy it after 1 second.
    // And it needs to go foward to hit something so we use the translate with a direction for that.

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var enemy = collision.transform.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
    #endregion
}
