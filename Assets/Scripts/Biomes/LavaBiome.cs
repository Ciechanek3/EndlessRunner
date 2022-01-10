using StateMachine;
using System;

namespace Biome
{
    public class LavaBiome : BiomesBaseState
    {
        public override Type Tick()
        {
            BiomeBehaviour();
            if (currentBiomeScore >= scoreRequired)
            {
                return typeof(DefaultBiome);
            }
            return null;
        }

        public override void BiomeBehaviour()
        {
        }
    }
}
