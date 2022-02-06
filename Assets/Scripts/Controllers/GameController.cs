using Movement;
using Platform;
using StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using Score;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Health playerHealth;
        [SerializeField]
        private PlayerMovement playerMovement;
        [SerializeField]
        private Canvas gameOverCanvas;
        [SerializeField]
        private StateMachineManager stateMachineManager;
        [SerializeField]
        private GameObject platform;
        [SerializeField]
        private ScoreController score;
        [SerializeField]
        private AudioSource audioSource;

        private void OnEnable()
        {
            playerHealth.OnPlayerDead += GameOver;
            stateMachineManager.OnStateChanged += ChangeBackground;
        }

        private void OnDisable()
        {
            playerHealth.OnPlayerDead += GameOver;
            stateMachineManager.OnStateChanged -= ChangeBackground;
        }

        private void GameOver()
        {
            playerMovement.enabled = false;
            platform.SetActive(false);
            score.enabled = false;
            audioSource.gameObject.SetActive(false);
            gameOverCanvas.gameObject.SetActive(true);
        }

        private void ChangeBackground(BaseState state)
        {
            var currState = state as BiomesPoolingBaseState;
            RenderSettings.skybox = currState.PlatformPooler.BiomeType.Background;
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene("Gameplay");
        }

        public void OnQuitClick()
        {
            Application.Quit();
        }
    }
}

