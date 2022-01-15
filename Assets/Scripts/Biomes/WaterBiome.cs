using StateMachine;
using System;

namespace Biome
{
    public class WaterBiome : BiomesPoolingBaseState
    {
        public override Type Tick()
        {
            if (score.CurrentBiomeScore >= ScoreRequired)
            {
                score.CurrentBiomeScore = 0;
                return typeof(LavaBiome);
            }
            return null;
        }
    }
}
