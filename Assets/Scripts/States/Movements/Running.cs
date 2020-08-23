using System;
using Task.Player;
using UnityEngine;

namespace States.Movements
{
    public class Running : Moving, IState
    {
        public float speed = 4.0f;
        
        public void HoldState(float[] args)
        {
            Debug.Log("I'm Moving here taking" + speed + args[0] + args[1]);
            Player.Instance.gameObject.transform.Translate(new Vector3(args[0],0,args[1]) * speed * 1);
        }
    }
}