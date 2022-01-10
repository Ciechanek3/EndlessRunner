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

    public BiomeType GetCurrentBiome()
    {
        switch(platformStateMachine.CurrentState)
        {
            case DefaultBiome biome:
                return defaultBiome;
            case WaterBiome biome:
                return waterBiome;
            case LavaBiome biome:
                return lavaBiome;
            default:
                return defaultBiome;
        }
    }
}
