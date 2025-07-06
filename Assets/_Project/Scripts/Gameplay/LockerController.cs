using UnityEngine;

namespace Echoes.Gameplay
{
    public class LockerController : MonoBehaviour, IClickable
    {
        [Header("Stats")] 
        [SerializeField] private string itemName;
        [SerializeField] [Range(0, 2)] private int fillIndex;
        [SerializeField] private LockerHandler lockerHandler;
        
        public void Click() => lockerHandler.OpenLocker(fillIndex);
    }
}
