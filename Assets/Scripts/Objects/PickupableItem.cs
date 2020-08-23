using DefaultNamespace;
using UnityEngine;

namespace Objects
{
    public class PickupableItem : MonoBehaviour, IUse
    {
        public void Use()
        {
            Debug.Log("Item Pickedup");
            this.gameObject.SetActive(false);
        }
    }
}