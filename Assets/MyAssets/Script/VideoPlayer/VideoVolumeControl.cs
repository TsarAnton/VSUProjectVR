using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(Slider))]
public class VideoVolumeControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;

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
        videoPlayer.SetDirectAudioVolume(0, value);
    }
}
