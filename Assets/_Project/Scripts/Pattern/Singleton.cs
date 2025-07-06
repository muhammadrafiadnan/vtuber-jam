using UnityEngine;

namespace Echoes.Pattern
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance;
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}