using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platform;

namespace Biome
{
    [CreateAssetMenu(menuName = "My Assets/Biome")]
    public class BiomeType : ScriptableObject
    {
        [SerializeField]
        private List<PlatformElement> platforms;
        [SerializeField]
        private List<GameObject> background;

        public List<PlatformElement> Platforms { get => platforms; set => platforms = value; }
    }
}   