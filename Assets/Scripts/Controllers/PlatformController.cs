using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{   
    [SerializeField]
    private PlatformPooler platformPooler;
    [SerializeField]
    private int platformsEnabled;
    [SerializeField]
    private Platform startingPlatform;

    private List<Platform> platformElements = new List<Platform>();
    

    private void Awake()
    {
        platformPooler.InstantiateObjectsToPool();
    }

    private void Start()
    {
        var firstPlatform = platformPooler.GetRandomObjectFromPool(startingPlatform.EndOfPlatform);
        platformElements.Add(firstPlatform);
        for (int i = 1; i < platformsEnabled; i++)
        {
            Debug.LogError(i);
            var platform = platformPooler.GetRandomObjectFromPool(platformElements[i - 1].EndOfPlatform);
            Debug.LogError(platform);
            platformElements.Add(platform);
        }
    }

}
