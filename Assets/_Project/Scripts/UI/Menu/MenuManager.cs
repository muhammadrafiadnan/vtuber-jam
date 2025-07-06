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
        public void NewGame(int scene)
        {
            PlayerPrefs.DeleteKey("LevelAt");
            SceneManager.LoadScene(scene);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
