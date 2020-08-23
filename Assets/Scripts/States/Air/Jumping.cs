using States;
using UnityEngine;

namespace Task.Player.States.Air
{
    public class Jumping : MonoBehaviour, IState
    {
        public float speed = 1.0f;
        public bool Doable()
        {
            return false;
        }

        public void StartState()
        {
            Debug.Log("I'm Jumping here taking" + speed);
            
        }

        public void HoldState(float[] args)
        {
            
        }

        public void EndState()
        {
            
        }
    }
}