using StateMachine;
using System;

namespace Biome
{
    public class LavaBiome : BiomesBaseState
    {
        public override Type Tick()
        {
            BiomeBehaviour();
            if (score.CurrentBiomeScore >= scoreRequired)
            {
                score.CurrentBiomeScore = 0;
                return typeof(DefaultBiome);
            }
            return null;
        }

        public override void BiomeBehaviour()
        {
        }
    }
}
