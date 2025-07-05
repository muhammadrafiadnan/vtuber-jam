using UnityEngine;
using UnityEngine.SceneManagement;

namespace Echoes
{
    public class MainMenu : MonoBehaviour
    {
        public void ChooseScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
