using Task.Player;
using Task.Player.Controller;
using UnityEngine;

namespace States.Ducking
{
    public class SuperDash : IState
    {
        protected Player Player;
        private const float DashSpeed = 500f;
        public bool Doable()
        {
            return true;
        }

        public void StartState(Player player)
        {
            Debug.Log("You got into SUPPER DOBBER DASH");
            Player = player;
            Player.GetComponent<Rigidbody>().AddForce(Vector3.forward * DashSpeed);
        }

        public void HoldState()
        {
            if ( Player.GetComponent<Rigidbody>().velocity.magnitude < 0.01 )
            {
                Player.GetComponent<PlayerController>().ChangeState(Player.GetComponent<PlayerController>().States.MovingState);
            }
        }

        public void HandleInput()
        {
            
        }
        
        public void Trigger(bool isEnter, Collider other)
        {
            
        }
        
        public void Collider(bool isEnter, Collider other)
        {
            
        }

        public void EndState()
        {
            Debug.Log("You're Out from SUPPER DOBBER DASH");
        }
    }
}