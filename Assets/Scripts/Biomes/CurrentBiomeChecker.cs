using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Biome;
using StateMachine;

public class CurrentBiomeChecker : MonoBehaviour
{
    [SerializeField]
    private StateMachineManager platformStateMachine;
    [SerializeField]
    private BiomeType defaultBiome;
    [SerializeField]
    private BiomeType waterBiome;
    [SerializeField]
    private BiomeType lavaBiome;

    public StateMachineManager PlatformStateMachine { get => platformStateMachine; set => platformStateMachine = value; }

    public BiomeType GetCurrentBiome()
    {
        switch(PlatformStateMachine.CurrentState)
        {
            case DefaultBiome a:
                return defaultBiome;
            case WaterBiome a:
                return waterBiome;
            case LavaBiome a:
                return lavaBiome;
            default: 
                return defaultBiome;
        }
    }
}
