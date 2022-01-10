using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform
{
    public class StartingPlatformDisabler : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}

