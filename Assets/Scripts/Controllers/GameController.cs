using Movement;
using Platform;
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

        private void OnEnable()
        {
            playerHealth.OnPlayerDead += GameOver;
        }

        private void OnDisable()
        {
            playerHealth.OnPlayerDead += GameOver;
        }

        private void GameOver()
        {
            playerMovement.enabled = false;
            gameOverCanvas.gameObject.SetActive(true);
        }
    }
}

