using Score;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerStats playerStats;
        [SerializeField]
        private Material playerMaterial;

        private void Start()
        {
            playerMaterial.color = playerStats.color;
        }
    }
}