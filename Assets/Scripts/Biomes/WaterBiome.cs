using StateMachine;
using System;

namespace Biome
{
    public class WaterBiome : BiomesBaseState
    {
        public override Type Tick()
        {
            BiomeBehaviour();
            if (score.CurrentBiomeScore >= scoreRequired)
            {
                score.CurrentBiomeScore = 0;
                return typeof(LavaBiome);
            }
            return null;
        }

        public override void BiomeBehaviour()
        {
        } 
    }
}
