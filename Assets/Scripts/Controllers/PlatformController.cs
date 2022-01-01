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
    [SerializeField]
    private float platformSpeed;

    private List<Platform> platformElements = new List<Platform>();
    private Vector3 move = new Vector3();



    private void Awake()
    {
        platformPooler.InstantiateObjectsToPool();
        move = new Vector3(0, 0, platformSpeed * Time.deltaTime);
    }
   
    private void Start()
    {
        platformElements.Add(startingPlatform);
        var firstPlatform = platformPooler.GetRandomObjectFromPool(startingPlatform.EndOfPlatform);
        platformElements.Add(firstPlatform);
        for (int i = 1; i < platformsEnabled; i++)
        {
            var platform = platformPooler.GetRandomObjectFromPool(platformElements[i - 1].EndOfPlatform);
            platformElements.Add(platform);
        }
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        foreach (Platform platform in platformElements)
        {
            platform.gameObject.transform.position += move;
        }
    }

}
