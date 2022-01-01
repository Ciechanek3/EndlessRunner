using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField]
    private Camera mainCamera;

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
        foreach (Platform pooledPlatform in platformElements)
        {
            pooledPlatform.gameObject.transform.position += move;
            if(pooledPlatform.EndOfPlatform.gameObject.transform.position.z > mainCamera.transform.position.z)
            {
                platformPooler.ReturnObjectToPool(pooledPlatform);
                var platform = platformPooler.GetRandomObjectFromPool(platformElements.Last().EndOfPlatform);
                platformElements.Add(platform);
            }
        }
    }

}
