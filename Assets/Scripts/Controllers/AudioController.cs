using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource musicAudioSource;
        [SerializeField]
        private AudioSource otherAudioSource;
        [SerializeField]
        private SoundVolume soundVolume;

        private void OnEnable()
        {
            musicAudioSource.volume = soundVolume.MusicVolume;
            otherAudioSource.volume = soundVolume.OtherVolume;
        }
    }
}

