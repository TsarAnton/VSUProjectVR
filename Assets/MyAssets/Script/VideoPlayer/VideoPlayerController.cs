using UnityEngine;
using TMPro;
using UnityEngine.Video;
using System.Collections.Generic;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public TMP_Dropdown videoDropdown;
    public List<VideoClip> videoClips;

    public void PlaySelectedVideo()
    {
        // Получаем индекс выбранного видео
        int selectedVideoIndex = videoDropdown.value;

        // Проверяем, что индекс находится в допустимом диапазоне
        if (selectedVideoIndex >= 0 && selectedVideoIndex < videoClips.Count)
        {
            // Устанавливаем выбранное видео в VideoPlayer и воспроизводим его
            videoPlayer.clip = videoClips[selectedVideoIndex];
            videoPlayer.Play();
        }
    }
}
