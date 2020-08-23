using Task.Player;
using UnityEngine;

namespace States
{
    public class Disabled : IState
    {
        protected Player Player;

        public bool Doable()
        {
            return true;
        }
        public void StartState(Player player)
        {
            Player = player;
        }
        public void HoldState()
        {
            
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
            
        }
    }
}