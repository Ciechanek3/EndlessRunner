using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreCounter;
    [SerializeField]
    private PlatformController platformController;

    private int score = 0;

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
        SetScoreOnUI();
    }

    private void SetScoreOnUI()
    {
        scoreCounter.text = "Score: " + score.ToString();
    }
}
