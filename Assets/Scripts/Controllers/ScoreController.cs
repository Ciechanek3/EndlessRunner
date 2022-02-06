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
        private TextMeshProUGUI bestScoreCounter;
        [SerializeField]
        private PlatformController platformController;

        private int score = 0;
        private int currentBiomeScore = 0;

        public int CurrentBiomeScore { get => currentBiomeScore; set => currentBiomeScore = value; }
        public int Score { get => score; }

        private void Awake()
        {
            bestScoreCounter.text = "Best Score: " + PlayerPrefs.GetInt("BestScore").ToString();
        }

        private void OnEnable()
        {
            platformController.OnPlatformDisabled += AddScore;
        }

        private void OnDisable()
        {
           platformController.OnPlatformDisabled -= AddScore;
            if (Score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", Score);
                PlayerPrefs.Save();
            }
        }

        private void AddScore()
        {
            score++;
            currentBiomeScore++;
            SetScoreOnUI();
        }

        private void SetScoreOnUI()
        {
            scoreCounter.text = "Score: " + Score.ToString();
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}

