using Echoes.Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Echoes.UI
{
    public class LevelSelection : MonoBehaviour
    {
        public Button[] lvlButtons;

        void Start()
        {
            var levelAt = PlayerPrefs.GetInt("levelAt", 2);

            for (var i = 0; i < lvlButtons.Length; i++)
            {
                var levelIndex = i + 2;
                if (i + 2 > levelAt)
                {
                    lvlButtons[i].interactable = false;
                }
                lvlButtons[i].onClick.AddListener(() => GoToLevel(levelIndex));
            }
        }

        private void GoToLevel(int index) => SceneTransition.Instance.LoadSceneIndex(index);
    }

}
