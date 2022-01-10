using UnityEngine;
using Platform;
using System.Collections.Generic;
using System;

namespace StateMachine
{
    public abstract class BiomesBaseState : BaseState
    {
        
        [SerializeField]
        protected int scoreRequired;

        protected int currentBiomeScore;
        protected PlatformController platformController;

        private void Awake()
        {
            platformController = GetComponentInParent<PlatformController>();
        }

        protected void OnEnable()
        {
            platformController.OnPlatformDisabled += IncrementBiomeScore;
        }

        protected void OnDisable()
        {
            platformController.OnPlatformDisabled -= IncrementBiomeScore;
        }

        public abstract void BiomeBehaviour();

        public void IncrementBiomeScore()
        {
            currentBiomeScore++;
        }
    }
}
