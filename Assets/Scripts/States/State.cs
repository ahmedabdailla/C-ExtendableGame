using System.IO;
using System.Linq;
using States.Movements;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using States.Ducking;
using Task.Player;
using Task.Player.States.Air;

namespace States
{
    public interface IState
    {
        bool Doable();
        void StartState(Player _player);
        void HoldState();
        void HandleInput();
        void Trigger(bool isEnter, Collider other);
        void Collider(bool isEnter, Collider other);
        void EndState();
    }

    public class States 
    {
        public Moving MovingState = new Moving();
        public Running RunningState = new Running();
        public Disabled DisabledState = new Disabled();
        public Ducking.Ducking DuckingState = new Ducking.Ducking();
        public SuperDash SuperDashState = new SuperDash();
        public Jumping JumpingState = new Jumping();
        public Flipping FlippingState = new Flipping();
        public Diving DivingState = new Diving();
    }
}