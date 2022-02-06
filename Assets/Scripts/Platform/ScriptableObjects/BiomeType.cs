using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform;

namespace Biome
{
    [CreateAssetMenu(menuName = "Biome/Biome")]
    public class BiomeType : ScriptableObject
    {
        [SerializeField]
        private List<PlatformElement> platforms;
        [SerializeField]
        private Material background;

        public List<PlatformElement> Platforms { get => platforms; set => platforms = value; }
        public Material Background { get => background; set => background = value; }
    }
}   