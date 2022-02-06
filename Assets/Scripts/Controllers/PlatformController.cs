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

        private int biomesLength;
        private float platformSpeedMultiplier = 1;
        private float differenceValue = 0;
        private bool shouldAssignDifferenceValue = true;
        private List<PlatformElement> platformElements = new List<PlatformElement>();

        public int PlatformsEnabled { get => platformsEnabled; set => platformsEnabled = value; }
        public float PlatformSpeedMultiplier { get => platformSpeedMultiplier; set => platformSpeedMultiplier = value; }
        public int BiomesLength { get => biomesLength; set => biomesLength = value; }

        private void Awake()
        {
            BiomesLength = platformsEnabled;
        }

        private void OnEnable()
        {
            platformStateMachineManager.OnStateChanged += ResetDifferenceFlag;
        }

        private void OnDisable()
        {
            platformStateMachineManager.OnStateChanged += ResetDifferenceFlag;
        }

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

        public void MovePlatform(BiomesPoolingBaseState currState, BiomesPoolingBaseState nextState)
        {
            for (int i = 0; i < platformElements.Count; i++)
            {
                platformElements[i].gameObject.transform.Translate(platformElements[i].transform.forward * Time.deltaTime * platformSpeed * platformSpeedMultiplier);
            }

            if (!(platformElements[0].EndOfPlatform.gameObject.transform.position.z > mainCamera.transform.position.z)) return;

            OnPlatformDisabled?.Invoke();

            currState.PlatformPooler.ReturnObjectToPool(platformElements[0]);
            PlatformElement platform = nextState.PlatformPooler.GetRandomObjectFromPool(platformElements.Last().EndOfPlatform);
            platformElements.Add(platform);
            platformElements.RemoveAt(0);
        }
        
        public void ResetDifferenceFlag(BaseState state)
        {
            shouldAssignDifferenceValue = true;
        }
    }
}
