using Movement;
using System;
using UnityEngine;

namespace StateMachine
{
    public class ForestBiome : BiomesPoolingBaseState
    {
        [SerializeField]
        private PlayerMovement playerMovement;
        public override Type Tick()
        {
            var result = base.Tick();
            if (result == null)
            {
                playerMovement.MoveSpeedMultiplier = 1.2f;
            }
            else
            {
                playerMovement.MoveSpeedMultiplier = 1.0f;
            }
            return result;
        }
    }
}