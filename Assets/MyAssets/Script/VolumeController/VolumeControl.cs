using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Slider))]
public class VolumeControl : MonoBehaviour
{
    public List<AudioSource> audioSource;
    public bool type;

    private Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();

        // Установка функции обратного вызова для изменения громкости при изменении значения слайдера
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    private void OnVolumeSliderChanged(float value)
    {
        // Изменение громкости звука видео в соответствии со значением слайдера
        for(int i = 0 ; i < audioSource.Count; i++) {
            audioSource[i].volume = value;
        }
        if(type) {
            GlobalVolume.instance.ambientVolume = value;
        } else {
            GlobalVolume.instance.effectsVolume = value;
        }
    }
}
