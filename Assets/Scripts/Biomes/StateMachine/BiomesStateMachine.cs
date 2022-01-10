using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;

namespace Biome
{
    public class BiomesStateMachine : MonoBehaviour
    {

        private void Awake()
        {
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            var states = new Dictionary<Type, BaseState>()
        {
            { typeof(DefaultBiome), GetComponent<DefaultBiome>() },
            { typeof(WaterBiome), GetComponent<WaterBiome>() },
            { typeof(LavaBiome), GetComponent<LavaBiome>() }              
        };
            StateMachineManager stateMachineManager = GetComponent<StateMachineManager>();
            stateMachineManager.SetStates(states);
        }
    }
}

