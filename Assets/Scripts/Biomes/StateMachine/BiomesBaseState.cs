using UnityEngine;
using Platform;

namespace StateMachine
{
    public abstract class BiomesBaseState : BaseState
    {        
        [SerializeField]
        private int scoreRequired;
        [SerializeField]
        private PlatformController platformController;

        public abstract void BiomeBehaviour();
        public abstract void IncrementBiomeScore();
    }
}
