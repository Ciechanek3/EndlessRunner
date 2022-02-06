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

        private void Start()
        {
            InstantiateObjectsToPool();
        }

        public void InstantiateObjectsToPool()
        {
            for (int i = 0; i < biomeType.Platforms.Count; i++)
            {
                for (int j = 0; j < amountOfObjectsToPool; j++)
                {
                    AddElementToPool(i);
                }
            }
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

        public void ReturnObjectToPool(PlatformElement platform)
        {
            PooledPlatforms.Add(platform);
            platform.gameObject.SetActive(false);
        }

        public void AddElementToPool(int index)
        {
            var pooledPlatform = Instantiate(biomeType.Platforms[index], transform);
            pooledPlatform.gameObject.SetActive(false);
            PooledPlatforms.Add(pooledPlatform);
        }

        public void AddRandomElementToPool()
        {
            var pooledPlatform = Instantiate(biomeType.Platforms[GetRandomPlatformIndex(biomeType.Platforms.Count)], transform);
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