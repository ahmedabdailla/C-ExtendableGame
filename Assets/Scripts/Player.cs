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
        private static Player _instance = null;  
        public static Player Instance  
        {  
            get  
            {  
                if (_instance == null)  
                {  
                    _instance = new Player();  
                }  
                return _instance;  
            }  
        }
        
        [SerializeField, SerializeReference]
        public IState state = new Running();

        public IState GetState()
        {
            return state;
        }

        public void ChangeState(IState newState)
        {
            if(state.Doable()){
            state.EndState();
            state = newState;
            state.StartState();
            }
            else
            {
            }
        }
    }
}
