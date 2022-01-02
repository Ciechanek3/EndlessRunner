using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Biome")]
public class Biome : ScriptableObject
{
    [SerializeField]
    private List<Platform> platforms;
    [SerializeField]
    private int scoreToChangeBiome;
    [SerializeField]
    private List<GameObject> background;
}
