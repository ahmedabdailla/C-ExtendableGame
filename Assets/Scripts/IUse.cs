using UnityEngine;

namespace Task.Player
{
    public interface IUse
    {
        void Use();
    }

    public class Use
    {
        private IUse _use;
        private bool _interacting = false;
        private GameObject _interactableActor;

        public void HandleInput()
        {
            var use = Input.GetButton("Fire2");
            if (use && _interacting == false && _interactableActor != null)
            {
                _interacting = true;
                _use = _interactableActor.GetComponent<IUse>();
                _use.Use();
                _interacting = false;
            }
        }

        public void Trigger(bool isEnter, Collider other)
        {
            if (other.CompareTag("Useable"))
            {
                if (isEnter)
                {
                    _interactableActor = other.gameObject;
                }
                else
                {
                    _interactableActor = null;
                }
            }
        }
    }
}