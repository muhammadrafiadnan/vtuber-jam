using UnityEngine;
using UnityEngine.UI;

namespace Echoes.UI
{
    public class GameWinHandler : GameUIBase
    {
        // Win
        [SerializeField] private Button nextButtonUI;
        
        // Methods
        protected override void InitOnStart()
        {
            base.InitOnStart();
            nextButtonUI.onClick.AddListener(OnRetryButton);
        }

        private void OnRetryButton()
        {
            // AudioManager.Instance.PlayAudio(Musics.ButtonSfx);
            // SceneTransitionManager.Instance.LoadSelectedScene(SceneState.MainMenu);
        }
    }
}