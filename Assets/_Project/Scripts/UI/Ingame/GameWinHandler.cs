using Echoes.Managers;
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
            nextButtonUI.onClick.AddListener(OnNextButton);
        }

        private void OnNextButton()
        {
            // AudioManager.Instance.PlayAudio(Musics.ButtonSfx);
            // SceneTransition.Instance.LoadSelectedScene(SceneState.NextLevel);
        }
    }
}