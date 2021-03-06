using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    public class PlatformElement : MonoBehaviour
    {
        [SerializeField]
        private Transform startOfPlatform;
        [SerializeField]
        private Transform endOfPlatform;

        public Transform StartOfPlatform { get => startOfPlatform; set => startOfPlatform = value; }
        public Transform EndOfPlatform { get => endOfPlatform; set => endOfPlatform = value; }
    }
}
