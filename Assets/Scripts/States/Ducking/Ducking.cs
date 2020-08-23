using Task.Player;
using Task.Player.Controller;
using UnityEngine;

namespace States.Ducking
{
    public class Ducking : IState
    {
        protected Player Player;
        private float _movingSpeed = 0.5f;
        private int _charges = 0;
        private int _reqiuredCharges = 10;
        private bool _chargable = false;
        private float _chargecycle = 0;
        float elapsed = 0f;

        public bool Doable()
        {
            return true;
        }

        public void StartState(Player player)
        {
            Player = player;
            Debug.Log("You're ducking now");
            Player.transform.localScale -= new Vector3(0,0.5f,0);
        }

        public void HoldState()
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f) {
                elapsed = elapsed % 1f;
                _chargecycle++;
                EndChargeCycle();
            }
        }

        public void HandleInput()
        {
            var horizontalInput = Input.GetAxis ("Horizontal");
            var verticalInput = Input.GetAxis ("Vertical");
            if (horizontalInput != 0f || verticalInput != 0f)
            {
                Player.gameObject.transform.Translate(new Vector3(horizontalInput,0,verticalInput) * _movingSpeed * Time.deltaTime);
            }
            
            var Ducks = Input.GetButtonUp("Fire3");
            if (Ducks)
            {
                Player.GetComponent<PlayerController>().ChangeState(Player.GetComponent<PlayerController>().States.MovingState);
            }
            
            var charging = Input.GetButtonDown("Fire1");
            if (charging)
            {
                if (CheckChargeCycle())
                {
                    Charge();
                    Debug.Log(_charges);
                }
                else
                {
                    StartChargeCycle();
                }
            }
        }

        private void StartChargeCycle()
        {
            _chargable = true;
            _charges = 0;
            _chargecycle = 0;
        }

        private bool CheckChargeCycle()
        {
            return _chargable;
        }

        private bool EndChargeCycle()
        {
            if (CheckChargeCycle())
            {
                if (_chargecycle >= 3)
                {
                    _chargable = false;
                    _charges = 0;
                    _chargecycle = 0;
                    return true;
                }

                return false;
            }
            return false;
        }

        private void Charge()
        {
            _charges++;
            if (_charges >= _reqiuredCharges)
            {
                Charged();
            }
        }

        private void Charged()
        {
            Player.GetComponent<PlayerController>().ChangeState(Player.GetComponent<PlayerController>().States.SuperDashState);
        }
        
        public void Trigger(bool isEnter, Collider other)
        {
            
        }
        
        public void Collider(bool isEnter, Collider other)
        {
            
        }

        public void EndState()
        {
            Debug.Log("You left ducking");
            _chargable = false;
            _charges = 0;
            Player.transform.localScale += new Vector3(0,0.5f,0);

        }
    }
}