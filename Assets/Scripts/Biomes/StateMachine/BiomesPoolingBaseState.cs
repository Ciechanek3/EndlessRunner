using UnityEngine;
using Score;
using Platform;
using System.Collections.Generic;
using System;
using System.Linq;
using Biome;

namespace StateMachine
{
    public abstract class BiomesPoolingBaseState : BaseState
    {      
        [SerializeField]
        private PlatformPooler platformPooler;
        [SerializeField]
        protected ScoreController score;
        [SerializeField]
        protected PlatformController platformController;
        [SerializeField]
        protected BiomesPoolingBaseState nextBiome;

        private Type nextBiomeType;
        
        public PlatformPooler PlatformPooler { get => platformPooler; set => platformPooler = value; }

        protected void Awake()
        {
            nextBiomeType = nextBiome.GetType();
        }

        public override Type Tick()
        {
            MovePlatform();
            if (score.CurrentBiomeScore >= platformController.BiomesLength)
            {
                score.CurrentBiomeScore = 0;
                return nextBiomeType;
            }
            return null;
        }

        protected void MovePlatform()
        {
            platformController.MovePlatform(this, nextBiome);
        }

        protected void GetNextBiome()
        {

        }
    
    }
}
