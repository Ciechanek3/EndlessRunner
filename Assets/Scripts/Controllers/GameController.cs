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
        private PlatformController platformController;
        [SerializeField]
        private ScoreController score;

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
            platformController.enabled = false;
            score.enabled = false;
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

