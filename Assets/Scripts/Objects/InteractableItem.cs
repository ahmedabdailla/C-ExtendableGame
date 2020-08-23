using DefaultNamespace;
using UnityEngine;

namespace Objects
{
    public class InteractableItem : MonoBehaviour, IUse
    {
        public void Use()
        {
            Debug.Log("Interact");
        }
    }
}