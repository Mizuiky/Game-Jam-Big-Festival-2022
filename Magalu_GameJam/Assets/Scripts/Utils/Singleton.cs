using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;

        void Awake()
        {
            if (Instance == null)
                Instance = GetComponent<T>();
            else
                Destroy(this.gameObject);
        }
    }
}

