using StateMachine;
using System;

namespace Biome
{
    public class WaterBiome : BiomesBaseState
    {
        public override Type Tick()
        {
            BiomeBehaviour();
            if (currentBiomeScore >= scoreRequired)
            {
                return typeof(LavaBiome);
            }
            return null;
        }

        public override void BiomeBehaviour()
        {
            throw new NotImplementedException();
        } 
    }
}
