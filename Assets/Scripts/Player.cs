using System;
using States;
using States.Movements;

namespace Task.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using Task.Player.Controller;
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public IState state;
        public IState GetState()
        {
            return state;
        }
        public void ChangeState(IState newState)
        { 
            state = newState;
        }
    }
}
