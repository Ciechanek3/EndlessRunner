using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour, IObjectPooler
{
    [SerializeField]
    private List<Platform> platformsToPool;
    [SerializeField]
    private int amountOfObjectsToPool;

    private List<Platform> pooledPlatforms = new List<Platform>();    

    public List<Platform> PooledPlatforms { get => pooledPlatforms; }

    public void InstantiateObjectsToPool()
    {
        for (int i = 0; i < platformsToPool.Count; i++)
        {
            for (int j = 0; j < amountOfObjectsToPool; j++)
            {
                var pooledPlatform = Instantiate(platformsToPool[i], transform);
                pooledPlatform.gameObject.SetActive(false);
                PooledPlatforms.Add(pooledPlatform);
            }
        }
    }

    public void GetRandomObjectFromPool(Transform position)
    {
        int maxNumber = PooledPlatforms.Count;
        PooledPlatforms.RemoveAt(GetRandomNumber(maxNumber));
        var pooledPlatform = PooledPlatforms[GetRandomNumber(maxNumber)];
        pooledPlatform.StartOfPlatform = position;
    }

    public void ReturnObjectToPool(Platform platform)
    {
        PooledPlatforms.Add(platform);
        platform.gameObject.SetActive(false);
    }

    private int GetRandomNumber(int max)
    {
        return Random.Range(0, max);
    }

}
