using System.Collections.Generic;
using UnityEngine;
using Biome;

namespace Platform
{
    public class PlatformPooler : MonoBehaviour, IObjectPooler
    {
        [SerializeField]
        private List<BiomeType> biomeTypes;
        [SerializeField]
        private int amountOfObjectsToPool;

        private List<PlatformElement> pooledPlatforms = new List<PlatformElement>();
        private List<PlatformElement> platformTypes = new List<PlatformElement>();
        private int numberOfPlatformTypes;

        public List<PlatformElement> PooledPlatforms { get => pooledPlatforms; }
        public List<PlatformElement> PlatformTypes { get => platformTypes; set => platformTypes = value; }

        private void Awake()
        {
            for(int i = 0; i < biomeTypes.Count; i++)
            {
                for(int j = 0; j < biomeTypes[i].Platforms.Count; j++)
                {
                    PlatformTypes.Add(biomeTypes[i].Platforms[j]);
                }
            }
            numberOfPlatformTypes = PlatformTypes.Count;
        }

        public void InstantiateObjectsToPool()
        {
            for (int i = 0; i < numberOfPlatformTypes; i++)
            {
                for (int j = 0; j < amountOfObjectsToPool; j++)
                {
                    AddElementToPool(i);
                }
            }
        }

        public PlatformElement GetRandomObjectFromPool(Transform transform, BiomeType currentBiome)
        {
            if (PooledPlatforms.Count < 1)
            {
                AddRandomElementToPool(currentBiome);
            }
            var index = GetRandomPlatformIndex(PooledPlatforms.Count);
            var pooledPlatform = PooledPlatforms[index];
            PooledPlatforms.RemoveAt(index);
            pooledPlatform.transform.position -= pooledPlatform.StartOfPlatform.position - transform.position;
            pooledPlatform.gameObject.SetActive(true);
            return pooledPlatform;
        }

        public void ReturnObjectToPool(PlatformElement platform)
        {
            PooledPlatforms.Add(platform);
            platform.gameObject.SetActive(false);
        }

        public void AddElementToPool(int index)
        {
            var pooledPlatform = Instantiate(PlatformTypes[index], transform);
            pooledPlatform.gameObject.SetActive(false);
            PooledPlatforms.Add(pooledPlatform);
        }

        public void AddRandomElementToPool(BiomeType currentBiome)
        {
            var pooledPlatform = Instantiate(currentBiome.Platforms[GetRandomPlatformIndex(currentBiome.Platforms.Count)], transform);
            pooledPlatform.gameObject.SetActive(false);
            PooledPlatforms.Add(pooledPlatform);
        }

        private int GetRandomPlatformIndex(int max)
        {
            int index = Random.Range(0, max);
            return index;
        }
    }
}