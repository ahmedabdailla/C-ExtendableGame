using Task.Player;
using Task.Player.Controller;
using UnityEngine;

namespace States.Movements
{
    public class Moving : IState
    {
        public float speed = 1.0f;
        protected Player Player;
        public bool Doable()
        {
            return true;
        }

        public virtual void StartState(Player player)
        {
            Player = player;
        }

        public void HoldState()
        {
            
        }

        public virtual void HandleInput()
        {
            var horizontalInput = Input.GetAxis ("Horizontal");
            var verticalInput = Input.GetAxis ("Vertical");
            if (horizontalInput != 0f || verticalInput != 0f)
            {
                Player.gameObject.transform.Translate(new Vector3(horizontalInput,0,verticalInput) * speed * Time.deltaTime);
            }
            var Run = Input.GetButtonDown("Shift");
            if (Run)
            {
                Player.GetComponent<PlayerController>().ChangeState(Player.GetComponent<PlayerController>().States.RunningState);
            }
            SharedInput();
        }

        protected void SharedInput()
        {
            var jumping = Input.GetButton("Jump");    
            if (jumping)
            {
                Player.GetComponent<PlayerController>().ChangeState(Player.GetComponent<PlayerController>().States.JumpingState);
            }
            
            var ducking = Input.GetButton("Fire3");
            if (ducking)
            {
                Player.GetComponent<PlayerController>()
                    .ChangeState(Player.GetComponent<PlayerController>().States.DuckingState);
            }
        }
        
        public void Trigger(bool isEnter, Collider other)
        {
            
        }
        
        public void Collider(bool isEnter, Collider other)
        {
            
        }

        public virtual void EndState()
        {
            Debug.Log("You left Moving State");

        }
    }
}