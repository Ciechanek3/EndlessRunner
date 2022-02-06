using StateMachine;
using System;
using UnityEngine;

namespace Biome
{
    public class WaterBiome : BiomesPoolingBaseState
    {
        public override Type Tick()
        {
            var result = base.Tick();
            if (result == null)
            {
                platformController.PlatformSpeedMultiplier = 1.1f;
            }
            else
            {
                platformController.PlatformSpeedMultiplier = 1f;
            }
            return result;
        }
    }
}
