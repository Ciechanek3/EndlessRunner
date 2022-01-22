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
        private float time;
        private bool shouldReturnToPreviousPooler = true;
        private BiomesPoolingBaseState currentPoolerState;
        private Queue<BiomesPoolingBaseState> queueOfBiomes;

        public int PlatformsEnabled { get => platformsEnabled; set => platformsEnabled = value; }
        public int BiomesOffset { get => biomesOffset; set => biomesOffset = value; }

        private void Start()
        {
            BiomesOffset = platformsEnabled;
            SetBiome(platformStateMachineManager.CurrentState);
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
            platformStateMachineManager.OnStateChanged += SetBiome;
            platformStateMachineManager.OnListOfStatesCreated += InstantiateObjectsToPool;
        }

        private void OnDisable()
        {
            platformStateMachineManager.OnStateChanged -= SetBiome;
            platformStateMachineManager.OnListOfStatesCreated -= InstantiateObjectsToPool;
        }

        private void Update()
        {
            MovePlatform();
        }

        private void MovePlatform()
        {
            time += Time.deltaTime / 2000;
            for (int i = 0; i < platformElements.Count; i++)
            {
                platformElements[i].gameObject.transform.Translate(platformElements[i].transform.forward * Time.deltaTime * platformSpeed);
            }

            if (platformElements[0].EndOfPlatform.gameObject.transform.position.z > mainCamera.transform.position.z)
            {
                OnPlatformDisabled.Invoke();
                if (shouldReturnToPreviousPooler)
                {
                    previousPlatformPooler.ReturnObjectToPool(platformElements[0]);
                    biomesOffset--;
                    if (biomesOffset == 0)
                    {
                        shouldReturnToPreviousPooler = false;
                    }
                }
                else
                {
                    currentPlatformPooler.ReturnObjectToPool(platformElements[0]);
                    biomesOffset++;
                    if (biomesOffset == currentPoolerState.ScoreRequired)
                    {
                        shouldReturnToPreviousPooler = true;
                    }
                }
                platformElements.RemoveAt(0);
                PlatformElement platform = currentPlatformPooler.GetRandomObjectFromPool(platformElements.Last().EndOfPlatform);
                platformElements.Add(platform);
            }
        }

        private void InstantiateObjectsToPool(Dictionary<Type, BaseState> states)
        {
            foreach (var state in states)
            {
                var poolingState = state.Value as BiomesPoolingBaseState;
                poolingState.PlatformPooler.InstantiateObjectsToPool();
            }
        }

        private void SetBiome(BaseState nextState)
        {
            currentPoolerState = nextState as BiomesPoolingBaseState;
            previousPlatformPooler = currentPlatformPooler;
            currentPlatformPooler = currentPoolerState.PlatformPooler;
        }
    }
}
