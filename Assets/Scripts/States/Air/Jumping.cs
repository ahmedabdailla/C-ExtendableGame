using States;
using Task.Player.Controller;
using UnityEngine;

namespace Task.Player.States.Air
{
    public class Jumping : IState
    {
        protected Player Player;
        private float jumpHeight = 200f;
        private float _airSpeed = 1f;

        public bool Doable()
        {
            return true;
        }

        public virtual void StartState(Player player)
        {
            Player = player;
            Debug.Log("You're flying High");
            Player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
        }

        public void HoldState()
        {
            
        }

        public void HandleInput()
        {
            var horizontalInput = Input.GetAxis ("Horizontal");
            var verticalInput = Input.GetAxis ("Vertical");
            if (horizontalInput != 0f || verticalInput != 0f)
            {
                Player.gameObject.transform.Translate(new Vector3(horizontalInput,0,verticalInput) * _airSpeed * Time.deltaTime);
            }
            var jumping = Input.GetButton("Jump");    
            if (jumping)
            {
                Player.GetComponent<PlayerController>().ChangeState(Player.GetComponent<PlayerController>().States.FlippingState);
            }
            
            var ducking = Input.GetButton("Fire3");
            if (ducking)
            {
                Player.GetComponent<PlayerController>()
                    .ChangeState(Player.GetComponent<PlayerController>().States.DivingState);
            }
        }
        
        public void Trigger(bool isEnter, Collider other)
        {
            if (isEnter)
            {
                if (other.CompareTag("Ground"))
                {
                    Player.GetComponent<PlayerController>().ChangeState(Player.GetComponent<PlayerController>().States.MovingState);
                }
            }
        }
        
        public void Collider(bool isEnter, Collider other)
        {

        }

        public void EndState()
        {
            Debug.Log("you left Jumping");
        }
    }
}