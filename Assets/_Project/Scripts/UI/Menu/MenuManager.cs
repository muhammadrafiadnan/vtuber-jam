using System;
using Echoes.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Echoes.UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button startButtonUI;
        [SerializeField] private Button continueButtonUI;
        [SerializeField] private Button exitButtonUI;
        
        private void Start()
        {
            startButtonUI.onClick.AddListener(OpenNewLevelSelection);
            continueButtonUI.onClick.AddListener(OpenLevelSelection);
            exitButtonUI.onClick.AddListener(QuitGame);
        }
        
        private void OpenLevelSelection() => SceneTransition.Instance.LoadSelectedScene(SceneState.NextLevel);
        private void OpenNewLevelSelection()
        {
            PlayerPrefs.DeleteKey("LevelAt");
            SceneTransition.Instance.LoadSelectedScene(SceneState.NextLevel);
        }
        private void QuitGame() => Application.Quit();
    }
}
