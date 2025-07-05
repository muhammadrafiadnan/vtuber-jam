using UnityEngine;

namespace Echoes.Gameplay
{
    public class ItemController : MonoBehaviour
    {
        [Header("Stats")] 
        [SerializeField] private string itemName;
        [SerializeField] private bool isActive = true;
        
        [Space]
        [SerializeField] private GameObject puzzlePanelUI;

        public void ClickItem()
        {
            Debug.unityLogger.Log("ClickItem");
            // puzzlePanelUI.SetActive(true);
        }

    }
}