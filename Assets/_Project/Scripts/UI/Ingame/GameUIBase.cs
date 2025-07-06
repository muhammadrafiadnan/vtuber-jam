using UnityEngine;
using UnityEngine.UI;

namespace Echoes.UI
{
    public class GameUIBase : MonoBehaviour
    {
        [Header("UI")] 
        [SerializeField] private Button homeButtonUI;
        
        // Unity Callbacks
        private void Awake()
        {
            InitOnAwake();
        }

        private void Start()
        {
            InitOnStart();
        }
        
        protected virtual void InitOnAwake() { }
        protected virtual void InitOnStart()
        {
            homeButtonUI.onClick.AddListener(OnHomeButton);
        }
        
        private void OnHomeButton()
        {
            // FindObjectOfType<AudioManager>().PlayAudio(Musics.ButtonSfx);
            // SceneTransitionManager.Instance.LoadSelectedScene(SceneState.MainMenu);
        }
    }
}