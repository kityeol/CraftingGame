using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSlider : MonoBehaviour
{
    Slider bgmSlider;
    AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        bgmSlider = GetComponent<Slider>();
        bgmSlider.onValueChanged.AddListener(SetVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }
}
