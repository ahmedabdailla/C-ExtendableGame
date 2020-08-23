using Task.Player;
using UnityEngine;

namespace States.Movements
{
    public class Moving : MonoBehaviour, IState
    {
        public float speed = 1.0f;

        public bool Doable()
        {
            return false;
        }

        public void StartState()
        {
            Debug.Log("I'm Moving here taking" + speed);
        }

        public void HoldState(float[] args)
        {
            Debug.Log("I'm Moving here taking" + speed + args[0]);
            Player.Instance.gameObject.transform.Translate(new Vector3(args[0],0,args[1]) * speed * Time.deltaTime);
        }

        public void EndState()
        {
            
        }
    }
}