using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public ProjectileBase prefabProjectile;
    public Transform posistionToShoot;
    public float timeBetweenShoot = .3f;
    public Transform playerSideReference;

    private Coroutine _currentCoroutine;
    #endregion

    #region Methods

    // *Gun base explanation*
    // The ideia is to have a script to be reutilazable and manage the gun state of the game object.
    // We want our player to be able to hold the key down and shoot multiple projectiles.
    // In order to do that we use a coroutine with a delay.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
           _currentCoroutine = StartCoroutine(StartShoot());
        else if (Input.GetKeyUp(KeyCode.S))
            if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
    }

    IEnumerator StartShoot()
    {
        while (true) { 
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    private void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = posistionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
    #endregion
}
