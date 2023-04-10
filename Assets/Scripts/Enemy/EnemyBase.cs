using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public int damage = 10;
    #endregion

    #region Methods

    // *Enemy base explanation*
    // The ideia is to have a script to be reutilazable and manage the general behaviour of the enemys.
    // Before applying any damage we check if the game object has a health base component.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
            health.Damage(damage);
    }
    #endregion
}
