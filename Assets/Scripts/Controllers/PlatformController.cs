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
        protected StateMachineManager platformStateMachineManager;

        public event Action OnPlatformDisabled;

        private PlatformPooler prevPlatformPooler;
        private PlatformPooler currPlatformPooler;
        private List<PlatformElement> platformElements = new List<PlatformElement>();

        private void Start()
        {
            prevPlatformPooler = platformStateMachineManager.AvailableStates.Values.First().PlatformPooler;
        }

        private void OnEnable()
        {
            platformStateMachineManager.OnStateChanged += OnBiomeChange;
        }

        private void OnDisable()
        {
            platformStateMachineManager.OnStateChanged -= OnBiomeChange;
        }

        public int PlatformsEnabled { get => platformsEnabled; set => platformsEnabled = value; }

        public void InstantiateStartingPlatform(BiomesPoolingBaseState firstState)
        {
            platformElements.Add(startingPlatform);
            for (int i = 1; i <= PlatformsEnabled; i++)
            {
                var platform = firstState.PlatformPooler.GetRandomObjectFromPool(platformElements[i - 1].EndOfPlatform);
                platformElements.Add(platform);
            }
            platformElements.Remove(startingPlatform);
        }

        public void MovePlatform(BiomesPoolingBaseState currentState)
        {
            for (int i = 0; i < platformElements.Count; i++)
            {
                platformElements[i].gameObject.transform.Translate(platformElements[i].transform.forward * Time.deltaTime * platformSpeed);
            }

            if (!(platformElements[0].EndOfPlatform.gameObject.transform.position.z > mainCamera.transform.position.z)) return;

            OnPlatformDisabled.Invoke();

            prevPlatformPooler.ReturnObjectToPool(platformElements[0]);
            platformElements.RemoveAt(0);
            PlatformElement platform = currentState.PlatformPooler.GetRandomObjectFromPool(platformElements.Last().EndOfPlatform);
            platformElements.Add(platform);
        }

        public void OnBiomeChange(BiomesPoolingBaseState state)
        {
            var biomeState = state as BiomesPoolingBaseState;
            prevPlatformPooler = currPlatformPooler ?? biomeState.PlatformPooler;
            currPlatformPooler = biomeState.PlatformPooler;
        }
    }
}
