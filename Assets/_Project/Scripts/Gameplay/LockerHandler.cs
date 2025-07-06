using UnityEngine;

namespace Echoes.Gameplay
{
    public class LockerHandler : MonoBehaviour
    {
        [SerializeField] private GameObject[] fullFills;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseLocker();
            }
        }
        
        public void OpenLocker(int fillIndex)
        {
            gameObject.SetActive(true);
            fullFills[fillIndex].SetActive(true);
        }
        
        private void CloseLocker()
        {
            gameObject.SetActive(false);
            foreach (var fill in fullFills)
            {
                fill.SetActive(false);
            }
        }
        
    }
}