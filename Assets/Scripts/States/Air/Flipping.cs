using States;
using UnityEngine;

namespace Task.Player.States.Air
{
    public class Flipping : Jumping, IState
    {
        public override void StartState(Player player)
        {
            Player = player;
            Debug.Log("You're a Flipping Now");
            var transform = Player.transform;
            var targetAngles = transform.eulerAngles + 180f * Vector3.up; // what the new angles should be
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, 1 * Time.deltaTime); // lerp to new angles
        }
        
    }
}