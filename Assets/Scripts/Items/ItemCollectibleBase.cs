using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleBase : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    public string compareTag = "Player";
    #endregion

    #region Methods

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

    }
    #endregion
}
