using StateMachine;
using System;
using UnityEngine;

namespace Biome
{
    public class DefaultBiome : BiomesBaseState
    {
        public override Type Tick()
        {
            BiomeBehaviour();
            if (score.CurrentBiomeScore >= scoreRequired)
            {
                score.CurrentBiomeScore = 0;
                return typeof(WaterBiome);
            }
            return null;
        }

        public override void BiomeBehaviour()
        {
        }
    }
}
