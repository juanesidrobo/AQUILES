using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicaMixer, efectosMixer;
    public AudioSource vida, muerteEnemigo, gameOver, musicaDeFondo,ganar, golpear;
    public static AudioManager instance;

    [Range(-80,8)]
    public float masterVolumen, efectosVolumen;
    public Slider MusicaSlider, EfectosSlider;
    private void Awake()
    {
        if(instance == null)
        {
            instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(musicaDeFondo);
        MusicaSlider.value = masterVolumen;
        EfectosSlider.value = efectosVolumen;

        MusicaSlider.minValue = -80;
        MusicaSlider.maxValue = 8;

        EfectosSlider.minValue = -80;
        EfectosSlider.maxValue = 8;
    }

    // Update is called once per frame
    void Update()
    {
        MasterVolumen();
        EfectosVolumen();
    }
    public void MasterVolumen()
    {
        musicaMixer.SetFloat("musicaMixer", MusicaSlider.value);
    }
    public void EfectosVolumen()
    {
        efectosMixer.SetFloat("efectosMixer", EfectosSlider.value);
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
