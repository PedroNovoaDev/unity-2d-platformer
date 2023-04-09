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
