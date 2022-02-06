using StateMachine;
using System;
using UnityEngine;

namespace Biome
{
    public class LavaBiome : BiomesPoolingBaseState
    {
        public override Type Tick()
        {
            var result = base.Tick();
            if (result == null)
            {
                platformController.PlatformSpeedMultiplier = 0.9f;
            }
            else
            {
                platformController.PlatformSpeedMultiplier = 1f;
            }
            return result;
        }
    }
}
