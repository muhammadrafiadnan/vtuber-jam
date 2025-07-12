using Echoes.Pattern;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Echoes.Managers
{
    public class SceneTransition : Singleton<SceneTransition>
    {
        public void LoadSelectedScene(SceneState sceneState)
        {
            Time.timeScale = 1;
            switch (sceneState)
            {
                case SceneState.MainMenu:
                    LoadMainMenuScene();
                    break;
                case SceneState.CurrentLevel:
                    LoadCurrentGame();
                    break;
                case SceneState.NextLevel:
                    LoadNextGame();
                    break;
            }
        }
        
        public void LoadSceneIndex(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
        
        private void LoadMainMenuScene() => SceneManager.LoadScene(0);
        private void LoadCurrentGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        private void LoadNextGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}