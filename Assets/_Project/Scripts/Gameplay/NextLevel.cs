using UnityEngine;  
using UnityEngine.SceneManagement;

namespace Echoes.Gameplay
{

    public class NextLevel : MonoBehaviour
    {
        public int nextSceneLoad;
        public static NextLevel singleton;

        private void Awake()
        {
            singleton = this;
        }
        void Start()
        {
            nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
            Time.timeScale = 1;
        }
        public void Play()
        {
            SceneManager.LoadScene(nextSceneLoad);
            Time.timeScale = 1;

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }

    }
}
