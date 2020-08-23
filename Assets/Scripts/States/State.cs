using UnityEngine;

namespace States
{
    public interface IState
    {
        bool Doable();
        void StartState();
        void HoldState(float[] args);
        void EndState();
    }
}