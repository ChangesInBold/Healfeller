using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TextSlider : MonoBehaviour
{
    
    public TextMeshProUGUI VolumeValueText;
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    private void Start()
    {
        mixer.GetFloat("volume",out value);
        volumeSlider.value = value;
    }

    public void SetVolume()
    {
        mixer.SetFloat("volume",volumeSlider.value);
    }

     
     
}
