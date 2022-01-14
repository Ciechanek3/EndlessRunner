using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using StateMachine;
using Biome;

namespace Platform
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField]
        private PlatformPooler defaultPlatformPooler;
        [SerializeField]
        private PlatformPooler waterPlatformPooler;
        [SerializeField]
        private PlatformPooler lavaPlatformPooler;
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
        [SerializeField]
        private StateMachineManager platformStateMachineManager;

        public event Action OnPlatformDisabled;

        private List<PlatformElement> platformElements = new List<PlatformElement>();
        private Vector3 move = new Vector3();
        private PlatformPooler currentPlatformPooler;
        private PlatformPooler previousPlatformPooler;
        private int biomesOffset;

        public int PlatformsEnabled { get => platformsEnabled; set => platformsEnabled = value; }

        private void Start()
        {
            biomesOffset = platformsEnabled;
            currentPlatformPooler = GetCurrentBiomePlatformPooler(SetFirstBiome());
            previousPlatformPooler = currentPlatformPooler;
            Debug.LogError(currentPlatformPooler);
            InstantiateObjectsToPool();
            move = new Vector3(0, 0, platformSpeed * Time.deltaTime);
            platformElements.Add(startingPlatform);
            for (int i = 1; i <= PlatformsEnabled; i++)
            {
                var platform = currentPlatformPooler.GetRandomObjectFromPool(platformElements[i - 1].EndOfPlatform);
                platformElements.Add(platform);
            }
            platformElements.Remove(startingPlatform);
        }

        private void OnEnable()
        {
            platformStateMachineManager.OnStateChanged += ChangeBiome;
        }

        private void OnDisable()
        {
            platformStateMachineManager.OnStateChanged -= ChangeBiome;
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
            }

            if (platformElements[0].EndOfPlatform.gameObject.transform.position.z > mainCamera.transform.position.z)
            {
                OnPlatformDisabled.Invoke();
                if (biomesOffset > 0)
                {
                    Debug.LogError("Prev");
                    previousPlatformPooler.ReturnObjectToPool(platformElements[0]);
                    biomesOffset--;
                }
                else
                {
                    Debug.LogError("ACTUAL");
                    currentPlatformPooler.ReturnObjectToPool(platformElements[0]);                   
                }           
                platformElements.RemoveAt(0);
                PlatformElement platform = currentPlatformPooler.GetRandomObjectFromPool(platformElements.Last().EndOfPlatform);
                platformElements.Add(platform);
            }
        }

        private void InstantiateObjectsToPool()
        {
            defaultPlatformPooler.InstantiateObjectsToPool();
            waterPlatformPooler.InstantiateObjectsToPool();
            lavaPlatformPooler.InstantiateObjectsToPool();
        }

        private PlatformPooler GetCurrentBiomePlatformPooler(BaseState state)
        {
            switch(state)
            {
                case DefaultBiome a:
                    Debug.LogError("DEFAULT");
                    return defaultPlatformPooler;
                case WaterBiome a:
                    return waterPlatformPooler;
                    Debug.LogError("WATER");
                case LavaBiome a:
                    return lavaPlatformPooler;
                    Debug.LogError("Lava");
                default:
                    return defaultPlatformPooler;
            }
        }

        private void TestPlatformPooler(PlatformPooler p)
        {
            if(p == defaultPlatformPooler)
            {
                Debug.LogError("DEFAULT");
            }
            else if(p == waterPlatformPooler)
            {
                Debug.LogError("WATER");
            }
            else if (p == lavaPlatformPooler)
            {
                Debug.LogError("LAVA");
            }
                    
        }

        private void ChangeBiome(BaseState nextState)
        {
            previousPlatformPooler = currentPlatformPooler;
            currentPlatformPooler = GetCurrentBiomePlatformPooler(nextState);
            biomesOffset = platformsEnabled;
        }

        private BaseState SetFirstBiome()
        {
            Debug.LogError(platformStateMachineManager.CurrentState);            
            return platformStateMachineManager.CurrentState;     
        }
    }
}
