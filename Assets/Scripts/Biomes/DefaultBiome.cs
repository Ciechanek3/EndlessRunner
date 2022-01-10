using StateMachine;
using System;

namespace Biome
{
    public class DefaultBiome : BiomesBaseState
    {
        public override Type Tick()
        {
            BiomeBehaviour();
            if (currentBiomeScore >= scoreRequired)
            {
                return typeof(WaterBiome);
            }
            return null;
        }

        public override void BiomeBehaviour()
        {
            throw new NotImplementedException();
        }
    }
}
