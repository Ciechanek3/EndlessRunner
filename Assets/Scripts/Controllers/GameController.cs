using Movement;
using Platform;
using StateMachine;
using UnityEngine;

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
            //gameOverCanvas.gameObject.SetActive(true);
        }

        private void ChangeBackground(BaseState state)
        {
            var currState = state as BiomesPoolingBaseState;
            RenderSettings.skybox = currState.PlatformPooler.BiomeType.Background;
        }
    }
}

