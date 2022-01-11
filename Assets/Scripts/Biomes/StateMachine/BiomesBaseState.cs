using UnityEngine;
using Score;

namespace StateMachine
{
    public abstract class BiomesBaseState : BaseState
    {
        
        [SerializeField]
        protected int scoreRequired;
        [SerializeField]
        protected ScoreController score;

        public abstract void BiomeBehaviour();

    }
}
