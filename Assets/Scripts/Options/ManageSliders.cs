using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    public class ManageSliders : MonoBehaviour
    {
        [SerializeField]
        private SoundVolume soundVolume;
        [SerializeField]
        private Slider musicSlider;
        [SerializeField]
        private Slider otherSlider;

        private void OnEnable()
        {
            musicSlider.value = soundVolume.MusicVolume;
            otherSlider.value = soundVolume.OtherVolume;
        }

        public void OnMusicSliderChange()
        {
            soundVolume.SetMusicVolume(musicSlider.value);
        }

        public void OnOtherSliderChange()
        {
            soundVolume.SetOtherVolume(otherSlider.value);
        }
    }
}

