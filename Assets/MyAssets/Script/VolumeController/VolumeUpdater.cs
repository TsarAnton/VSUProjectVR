using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VolumeUpdater : MonoBehaviour
{
    public List<AudioSource> audioSource;
    public AudioSource ambient;

    public Slider ambientSlider;
    public Slider effectsSlider;

    private void Start()
    {
        //if(GlobalVolume.instance.changeVolume) {
        if(audioSource != null) {
            for(int i = 0; i < audioSource.Count; i++) {
                if(audioSource[i] != null) {
                    audioSource[i].volume = GlobalVolume.instance.effectsVolume;
                }
            }
        }
        if(ambient != null) {
            ambient.volume = GlobalVolume.instance.ambientVolume;
        }
    
        if(effectsSlider != null) {
            effectsSlider.value = GlobalVolume.instance.effectsVolume;
            ambientSlider.value = GlobalVolume.instance.ambientVolume;
        }
        //GlobalVolume.instance.changeVolume = false;
        //}
        //GlobalVolume.instance.changeVolume = false;
    }
}
