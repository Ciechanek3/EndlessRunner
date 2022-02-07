using TMPro;
using UnityEngine;
using Platform;
using Player;

namespace Score
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreCounter;
        [SerializeField]
        private TextMeshProUGUI bestScoreCounter;
        [SerializeField]
        private TextMeshProUGUI moneyCounter;
        [SerializeField]
        private PlatformController platformController;
        [SerializeField]
        private PlayerStats playerStats;
        
        private int score = 0;
        private int currentBiomeScore = 0;

        public int CurrentBiomeScore { get => currentBiomeScore; set => currentBiomeScore = value; }
        public int Score { get => score; }

        private void Awake()
        {
            bestScoreCounter.text = "Best Score: " + PlayerPrefs.GetInt("BestScore").ToString();
            moneyCounter.text = "Cash: " + playerStats.Money.ToString();
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

        public void UpdateMoney()
        {
            moneyCounter.text = "Cash: " + playerStats.Money.ToString();
        }

        public void ResetScore()
        {
            score = 0;
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
    }
}

