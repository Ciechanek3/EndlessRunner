using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using StateMachine;

namespace Platform
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField]
        private PlatformPooler platformPooler;
        [SerializeField]
        private int platformsEnabled;
        [SerializeField]
        private PlatformElement startingPlatform;
        [SerializeField]
        private float platformSpeed;
        [SerializeField]
        private Camera mainCamera;
        [SerializeField]
        private CurrentBiomeChecker currentBiomeChecker;

        public event Action OnPlatformDisabled;

        private List<PlatformElement> platformElements = new List<PlatformElement>();
        private Vector3 move = new Vector3();

        private void Awake()
        {
            platformPooler.InstantiateObjectsToPool();
            move = new Vector3(0, 0, platformSpeed * Time.deltaTime);
        }

        private void Start()
        {
            platformElements.Add(startingPlatform);
            for (int i = 1; i <= platformsEnabled; i++)
            {
                var platform = platformPooler.GetRandomObjectFromPool(platformElements[i - 1].EndOfPlatform, currentBiomeChecker.GetCurrentBiome());
                platformElements.Add(platform);
            }
            platformElements.Remove(startingPlatform);
        }

        private void Update()
        {
            MovePlatform();
        }

        private void MovePlatform()
        {
            for (int i = 0; i < platformElements.Count; i++)
            {
                platformElements[i].gameObject.transform.Translate(platformElements[i].transform.forward * Time.deltaTime * platformSpeed);
                if (platformElements[i].EndOfPlatform.gameObject.transform.position.z > mainCamera.transform.position.z)
                {
                    platformPooler.ReturnObjectToPool(platformElements[i]);
                    platformElements.RemoveAt(i);
                    var platform = platformPooler.GetRandomObjectFromPool(platformElements.Last().EndOfPlatform, currentBiomeChecker.GetCurrentBiome());
                    platformElements.Add(platform);
                    OnPlatformDisabled.Invoke();
                }
            }
        }
    }
}
