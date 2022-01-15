using UnityEngine;
using Score;
using Platform;

namespace StateMachine
{
    public abstract class BiomesPoolingBaseState : BaseState
    {

        [SerializeField]
        private int scoreRequired;
        [SerializeField]
        protected ScoreController score;
        
        protected PlatformController platformController;

        private void Awake()
        {
            platformController = GetComponentInParent<PlatformController>();
        }

        protected int ScoreRequired { get => scoreRequired; set => scoreRequired = value; }

    }
}
