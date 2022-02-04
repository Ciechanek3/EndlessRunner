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

        private Dictionary<BiomesPoolingBaseState, int> dictionaryOfBiomes = new Dictionary<BiomesPoolingBaseState, int>();
        private List<PlatformElement> platformElements = new List<PlatformElement>();
        private Vector3 move = new Vector3();
        private PlatformPooler currentPlatformPooler;
        private PlatformPooler previousPlatformPooler;
        private BiomesPoolingBaseState currentPoolerState;
        private int biomesOffset;
        private bool changePoolerFlag = true;

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
            dictionaryOfBiomes.Remove(dictionaryOfBiomes.Keys.First());
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
            for (int i = 0; i < platformElements.Count; i++)
            {
                platformElements[i].gameObject.transform.Translate(platformElements[i].transform.forward * Time.deltaTime * platformSpeed);
            }

            if (!(platformElements[0].EndOfPlatform.gameObject.transform.position.z > mainCamera.transform.position.z)) return;

            Debug.LogError(biomesOffset);
            OnPlatformDisabled.Invoke();

            if (changePoolerFlag)
            {
                biomesOffset = dictionaryOfBiomes.Values.First();
                currentPoolerState = dictionaryOfBiomes.Keys.First();
                dictionaryOfBiomes.Remove(dictionaryOfBiomes.Keys.First());
                changePoolerFlag = false;
            }

            currentPoolerState.PlatformPooler.ReturnObjectToPool(platformElements[0]);
            biomesOffset--;

            if (biomesOffset == 0)
            {
                changePoolerFlag = true;
            }

            platformElements.RemoveAt(0);
            PlatformElement platform = currentPoolerState.PlatformPooler.GetRandomObjectFromPool(platformElements.Last().EndOfPlatform);
            platformElements.Add(platform);
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
            dictionaryOfBiomes.Add(currentPoolerState, currentPoolerState.ScoreRequired);
            //currentPoolerState = dictionaryOfBiomes.Keys.First();
            currentPlatformPooler = currentPoolerState.PlatformPooler;
        }
    }
}
