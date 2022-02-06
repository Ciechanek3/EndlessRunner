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
        private StateMachineManager stateMachineManager;

        private void Awake()
        {
            InitializeStateMachine();
        }

        private void Start()
        {
            var baseState = stateMachineManager.CurrentState as BiomesPoolingBaseState;
            PlatformController platformController = GetComponentInParent<PlatformController>();
            platformController.InstantiateStartingPlatform(baseState);
        }

        private void InitializeStateMachine()
        {
            var states = new Dictionary<Type, BaseState>()
        {
            { typeof(DefaultBiome), GetComponent<DefaultBiome>() },
            { typeof(WaterBiome), GetComponent<WaterBiome>() },
            { typeof(LavaBiome), GetComponent<LavaBiome>() },
            { typeof(ForestBiome), GetComponent<ForestBiome>()}
        };
            stateMachineManager = GetComponent<StateMachineManager>();
            Debug.LogError(states.Values.First());
            stateMachineManager.SetStates(states);
        }
    }
}

