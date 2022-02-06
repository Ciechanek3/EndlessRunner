using StateMachine;
using System;
using UnityEngine;

namespace Biome
{
    public class DefaultBiome : BiomesPoolingBaseState
    {
        public override Type Tick()
        { 
            var result = base.Tick();
            return result;
        }
    }
}
