using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleBase : MonoBehaviour
{
    #region Variables
    [Header("Item Variables")]
    public ParticleSystem particleSystem;
    public string compareTag = "Player";
    #endregion

    #region Methods

    // *ItemCollectibleBase explanation*
    // The ideia is that the script is utilized in different itens and each overrides the methods to it's own needs.

    private void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // To check if the item should be collected we use the tag of the player.

        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {

        // And if collected we deactivate the game object and activate the VFX in the OnCollect function.

        OnCollect();
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) particleSystem.Play();
    }
    #endregion
}
