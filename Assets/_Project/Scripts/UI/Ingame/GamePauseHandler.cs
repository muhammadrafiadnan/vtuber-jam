using UnityEngine;
using UnityEngine.UI;

namespace Echoes.UI
{
    public class GamePauseHandler : GameUIBase
    {
        // Pause
        [SerializeField] private Button pauseButtonUI;
        [SerializeField] private Button retryButtonUI;
        [SerializeField] private Button resumeButtonUI;
        [SerializeField] private GameObject pausePanelUI;
        
        // Methods
        protected override void InitOnStart()
        {
            base.InitOnStart();
            pausePanelUI.SetActive(false);
            
            pauseButtonUI.onClick.AddListener(OnPauseButton);
            retryButtonUI.onClick.AddListener(OnRetryButton);
            resumeButtonUI.onClick.AddListener(OnResumeButton);
        }
        
        public void OnPauseButton()
        {
            // AudioManager.Instance.PlayAudio(Musics.ButtonSfx);
            pausePanelUI.SetActive(true);
            Time.timeScale = 0;
        }
        
        public void OnResumeButton()
        {
            // AudioManager.Instance.PlayAudio(Musics.ButtonSfx);
            pausePanelUI.SetActive(false);
            Time.timeScale = 1;
        }
        
        public void OnRetryButton()
        {
            // AudioManager.Instance.PlayAudio(Musics.ButtonSfx);
            // SceneTransitionManager.Instance.LoadSelectedScene(SceneState.CurrentLevel);
        }
    }
}