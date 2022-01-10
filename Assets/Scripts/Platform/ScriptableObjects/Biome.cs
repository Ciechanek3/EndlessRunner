using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform;

namespace Biome
{
    [CreateAssetMenu(menuName = "My Assets/Biome")]
    public class Biome : ScriptableObject
    {
        [SerializeField]
        private List<PlatformElement> platforms;
        [SerializeField]
        private int scoreToChangeBiome;
        [SerializeField]
        private List<GameObject> background;
    }
}   