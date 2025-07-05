using System;
using UnityEngine;

namespace Echoes.Pattern
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T instance;
        
        private void Awake()
        {
            if (instance == null)
            {
                Destroy(gameObject);
            }
            
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}