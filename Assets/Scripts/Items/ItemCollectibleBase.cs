using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleBase : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    #endregion

    #region Methods

    // *ItemCollectibleBase explanation*
    // The ideia is that the script is utilezed in different itens and each overrides the methods to it's own needs.
    // To check if the item was collected we use the trigger with the player.
    // And if collected we deactivate the game object and activate the VFX.

    private void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();
    }
    #endregion
}
