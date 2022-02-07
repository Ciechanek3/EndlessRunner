using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Player/PlayerStats", order = 1)]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField]
        private int startingHealth;
        [SerializeField]
        private int money;
        [SerializeField]
        private Color defaultColor;

        public Color color;

        private List<Color> ownedColors;

        public event Action<int> OnStartingHealthChanged;
        public event Action<int> OnCashChanged;

        public List<Color> OwnedColors { get => ownedColors; set => ownedColors = value; }
        public int StartingHealth
        {
            get => startingHealth;
            set
            {
                startingHealth = value;
                OnStartingHealthChanged?.Invoke(startingHealth);
            }
        }

        public int Money 
        { 
            get => money;
            set
            {
                money = value;
                OnCashChanged?.Invoke(money);
            }
        }

        public void ReturnToDefaultColor()
        {
            color = defaultColor;
        }
    }
}