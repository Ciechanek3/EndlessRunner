using System.Collections.Generic;
using UnityEngine;
using Biome;

namespace Platform
{
    public class PlatformPooler : MonoBehaviour, IObjectPooler
    {
        [SerializeField]
        private int amountOfObjectsToPool;
        [SerializeField]
        private BiomeType biomeType;

        private List<PlatformElement> pooledPlatforms = new List<PlatformElement>();

        public List<PlatformElement> PooledPlatforms { get => pooledPlatforms; }
        public BiomeType BiomeType { get => biomeType; set => biomeType = value; }

        private void Start()
        {
            InstantiateObjectsToPool();
        }

        public void InstantiateObjectsToPool()
        {
            for (int i = 0; i < BiomeType.Platforms.Count; i++)
            {
                for (int j = 0; j < amountOfObjectsToPool; j++)
                {
                    AddElementToPool(i);
                }
            }
        }

        public void AddElementToPool(int index)
        {
            var pooledPlatform = Instantiate(BiomeType.Platforms[index], transform);
            pooledPlatform.gameObject.SetActive(false);
            PooledPlatforms.Add(pooledPlatform);
        }

        public PlatformElement GetRandomObjectFromPool(Transform transform)
        {
            if (PooledPlatforms.Count < 1)
            {
                AddRandomElementToPool();
            }
            var index = GetRandomPlatformIndex(PooledPlatforms.Count);
            var pooledPlatform = PooledPlatforms[index];
            PooledPlatforms.RemoveAt(index);
            pooledPlatform.transform.position -= pooledPlatform.StartOfPlatform.position - transform.position;
            pooledPlatform.gameObject.SetActive(true);
            return pooledPlatform;
        }

        public void AddRandomElementToPool()
        {
            var pooledPlatform = Instantiate(BiomeType.Platforms[GetRandomPlatformIndex(BiomeType.Platforms.Count)], transform);
            pooledPlatform.gameObject.SetActive(false);
            PooledPlatforms.Add(pooledPlatform);
        }

        public void ReturnObjectToPool(PlatformElement platform)
        {
            PooledPlatforms.Add(platform);
            platform.gameObject.SetActive(false);
        }

        private int GetRandomPlatformIndex(int max)
        {
            int index = Random.Range(0, max);
            return index;
        }
    }
}