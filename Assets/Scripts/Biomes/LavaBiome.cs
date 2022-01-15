using StateMachine;
using System;

namespace Biome
{
    public class LavaBiome : BiomesPoolingBaseState
    {
        public override Type Tick()
        {
            if (score.CurrentBiomeScore >= ScoreRequired)
            {
                score.CurrentBiomeScore = 0;
                return typeof(DefaultBiome);
            }
            return null;
        }
    }
}
