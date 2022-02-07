using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "Sound/SoundVolume", order = 3)]
    public class SoundVolume : ScriptableObject
    {
        [SerializeField]
        [Range(0, 1)]
        private float musicVolume, otherVolume;

        public float MusicVolume { get => musicVolume; }
        public float OtherVolume { get => otherVolume; }


        public void SetMusicVolume(float volume)
        {
            musicVolume = volume;
        }

        public void SetOtherVolume(float volume)
        {
            otherVolume = volume;
        }
    }
}

