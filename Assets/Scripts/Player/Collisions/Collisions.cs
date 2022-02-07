using UnityEngine;
using Player;
using Score;

namespace Collisions
{
    public class Collisions : MonoBehaviour
    {
        [SerializeField]
        private ScoreController scoreController;
        [SerializeField]
        private PlayerStats playerStats;
        [SerializeField]
        private Health health;
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private AudioClip hitAudio;
        [SerializeField]
        private AudioClip getMoneyAudio;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Coin"))
            {
                collision.gameObject.SetActive(false);
                playerStats.Money++;
                scoreController.UpdateMoney();
                audioSource.clip = getMoneyAudio;
                audioSource.Play();
            }
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                collision.gameObject.SetActive(false);
                audioSource.clip = hitAudio;
                audioSource.Play();
                health.LoseHp();
            }
        }
    }
}

