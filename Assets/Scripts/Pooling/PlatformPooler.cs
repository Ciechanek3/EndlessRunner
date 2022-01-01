using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour, IObjectPooler
{
    [SerializeField]
    private List<Platform> platformsToPool;
    [SerializeField]
    private int amountOfObjectsToPool;

    private List<Platform> pooledPlatforms = new List<Platform>();
    private int numberOfPlatformTypes;

    public List<Platform> PooledPlatforms { get => pooledPlatforms; }
    public int NumberOfPlatformTypes { get => numberOfPlatformTypes; set => numberOfPlatformTypes = value; }

    private void Awake()
    {
        NumberOfPlatformTypes = platformsToPool.Count;
    }
    public void InstantiateObjectsToPool()
    {
        for (int i = 0; i < platformsToPool.Count; i++)
        {
            for (int j = 0; j < amountOfObjectsToPool; j++)
            {
                AddElementToPool(i);
            }
        }
    }

    public Platform GetRandomObjectFromPool(Transform transform)
    {
        if(PooledPlatforms.Count < 1)
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

    public void ReturnObjectToPool(Platform platform)
    {
        PooledPlatforms.Add(platform);
        platform.gameObject.SetActive(false);
    }

    public void AddElementToPool(int index)
    {
        var pooledPlatform = Instantiate(platformsToPool[index], transform);
        pooledPlatform.gameObject.SetActive(false);
        PooledPlatforms.Add(pooledPlatform);
    }

    public void AddRandomElementToPool()
    {
        var pooledPlatform = Instantiate(platformsToPool[GetRandomPlatformIndex(platformsToPool.Count)], transform);
        pooledPlatform.gameObject.SetActive(false);
        PooledPlatforms.Add(pooledPlatform);
    }

    private int GetRandomPlatformIndex(int max)
    {
        int index = Random.Range(0, max);
        return index;
    }

}
