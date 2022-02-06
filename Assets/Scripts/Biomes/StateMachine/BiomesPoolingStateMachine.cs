using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
using Platform;
using System.Linq;

namespace Biome
{
    public class BiomesPoolingStateMachine : MonoBehaviour
    {

        private void Awake()
        {
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            var states = new Dictionary<Type, BiomesPoolingBaseState>()
        {
            { typeof(DefaultBiome), GetComponent<DefaultBiome>() },
            { typeof(WaterBiome), GetComponent<WaterBiome>() },
            { typeof(LavaBiome), GetComponent<LavaBiome>() }              
        };
            StateMachineManager stateMachineManager = GetComponent<StateMachineManager>();
            stateMachineManager.SetStates(states);

            PlatformController platformController = GetComponentInParent<PlatformController>();
            platformController.InstantiateStartingPlatform(states.Values.First());
        }
    }
}

