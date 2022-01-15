using StateMachine;
using System;
using UnityEngine;

namespace Biome
{
    public class DefaultBiome : BiomesPoolingBaseState
    {
        public override Type Tick()
        {
            if (score.CurrentBiomeScore >= ScoreRequired)
            {
                score.CurrentBiomeScore = 0;
                return typeof(WaterBiome);
            }
            return null;
        }
    }
}
