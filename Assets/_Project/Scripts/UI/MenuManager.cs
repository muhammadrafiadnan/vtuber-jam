using UnityEngine;
using UnityEngine.SceneManagement;

namespace Echoes.UI
{
    public class MenuManager : MonoBehaviour
    {
        public void ChooseScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
