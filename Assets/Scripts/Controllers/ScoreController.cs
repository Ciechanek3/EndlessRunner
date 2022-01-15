using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Platform;

namespace Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreCounter;
        [SerializeField]
        private PlatformController platformController;

        private int score = 0;
        private int currentBiomeScore = 0;

        public int CurrentBiomeScore { get => currentBiomeScore; set => currentBiomeScore = value; }


        private void Awake()
        {
            currentBiomeScore = 0 + platformController.PlatformsEnabled;
        }

        private void OnEnable()
        {
            platformController.OnPlatformDisabled += AddScore;
        }

        private void OnDisable()
        {
            platformController.OnPlatformDisabled -= AddScore;
        }

        private void AddScore()
        {
            score++;
            currentBiomeScore++;
            SetScoreOnUI();
        }

        private void SetScoreOnUI()
        {
            scoreCounter.text = "Score: " + score.ToString();
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}

