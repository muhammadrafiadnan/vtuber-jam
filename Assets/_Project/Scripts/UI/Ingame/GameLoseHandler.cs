using Echoes.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Echoes.UI
{
    public class GameLoseHandler : GameUIBase
    {
        // Lose
        [SerializeField] private Button retryButtonUI;
        
        // Methods
        protected override void InitOnStart()
        {
            base.InitOnStart();
            retryButtonUI.onClick.AddListener(OnRetryButton);
        }

        private void OnRetryButton()
        {
            // AudioManager.Instance.PlayAudio(Musics.ButtonSfx);
            SceneTransition.Instance.LoadSelectedScene(SceneState.CurrentLevel);
        }
    }
}