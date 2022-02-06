using UnityEngine;
using Score;
using Platform;
using System.Collections.Generic;
using System;
using System.Linq;

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
        [SerializeField]
        protected PlatformController platformController;

        public int ScoreRequired { get => scoreRequired; set => scoreRequired = value; }
        public PlatformPooler PlatformPooler { get => platformPooler; set => platformPooler = value; }

        protected void MovePlatform()
        {
            platformController.MovePlatform(this);
        }
    
    }
}
