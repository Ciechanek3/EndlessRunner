using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
using System.Linq;

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
            { typeof(LavaBiome), GetComponent<LavaBiome>() },
            { typeof(WaterBiome), GetComponent<WaterBiome>() }
        };
            StateMachineManager stateMachineManager = GetComponent<StateMachineManager>();
            stateMachineManager.SetStates(states);
        }
    }
}

