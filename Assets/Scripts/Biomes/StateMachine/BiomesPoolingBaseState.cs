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
        private PlatformPooler platformPooler;
        [SerializeField]
        protected ScoreController score;

        protected PlatformController platformController;

        private void Awake()
        {
            platformController = GetComponentInParent<PlatformController>();
        }

        public int ScoreRequired { get => scoreRequired; set => scoreRequired = value; }
        public PlatformPooler PlatformPooler { get => platformPooler; set => platformPooler = value; }
    }
}
