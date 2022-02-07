using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Player
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private PlayerStats playerStats;
        [SerializeField]
        private TextMeshProUGUI hpText;

        private int currentHp;

        public event Action OnPlayerDead;

        private bool IsDead { get => currentHp <= 0; }

        public int CurrentHp { get => CurrentHp; }

        private void Awake()
        {
            currentHp = playerStats.StartingHealth;
            UpdateHpUI();
        }

        public void LoseHp()
        {
            currentHp--;
            UpdateHpUI();
            if (IsDead)
            {
                OnPlayerDead?.Invoke();
            }
        }

        public void GainHealth()
        {
            if (currentHp < 5)
            {
                currentHp++;
            }
        }

        private void UpdateHpUI()
        {
            hpText.text = "HP left: " + currentHp.ToString();
        }
    }
}

