using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Variables
        [Header("Instance")]
        public static T Instance;
        #endregion

        #region Methods

        // *Singleton explanation*
        // Singleton is a design pattern with the objective to have only 1 instance type of determined class.
        // The ideia is to implement the GameManager and other managers as a Singleton so we always have only 1 instance of it in the scene.
        // So when the Singleton is instantiated we check if it already exists.
        // If null we assign it to the variable Instance.
        // If already exists we destroy that gameObject.

        void Awake()
        {
            if (Instance == null)
                Instance = GetComponent<T>();
            else
                Destroy(gameObject);

        }
        #endregion
    }
}
