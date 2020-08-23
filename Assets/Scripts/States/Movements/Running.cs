using System;
using Task.Player;
using Task.Player.Controller;
using UnityEngine;

namespace States.Movements
{
    public class Running : Moving, IState
    {
        public float speed = 3.0f;

        public override void StartState(Player player)
        {
            base.StartState(player);
            Debug.Log("You're a Runner Now");
        }

        public override void HandleInput()
        {
            var horizontalInput = Input.GetAxis ("Horizontal");
            var verticalInput = Input.GetAxis ("Vertical");
            if (horizontalInput != 0f || verticalInput != 0f)
            {
                Player.gameObject.transform.Translate(new Vector3(horizontalInput,0,verticalInput) * speed * Time.deltaTime);
            }
            var Runs = Input.GetButtonUp("Shift");
            if (Runs)
            {
                Player.GetComponent<PlayerController>().ChangeState(Player.GetComponent<PlayerController>().States.MovingState);
            }
            SharedInput();
        }

        public override void EndState()
        {
            Debug.Log("You Left Running");
        }
    }
}