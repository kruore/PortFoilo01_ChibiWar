using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGA_EffectSound : MonoBehaviour
{
    public bool Repeating = false;
    public float RepeatTime = 2.0f;
    public float StartTime = 0.0f;
    public bool RandomVolume;
    public float minVolume = .4f;
    public float maxVolume = 1f;
    [SerializeField]
    private AudioSource soundComponent;
    public AudioClip soundTrack;

    void Start ()
    {
        soundComponent = GameObject.Find("GM_SoundManager").GetComponent<AudioSource>();
        soundComponent.clip = soundTrack;
        PlaySound();
        // RepeatSound();
        //if (RandomVolume == true)
        //{
        //    soundComponent.volume = Random.Range(minVolume, maxVolume);
        //    RepeatSound();
        //}
        //if (Repeating == true)
        //{
        //    InvokeRepeating("RepeatSound", StartTime, RepeatTime);
        //}
    }
    //private void OnEnable()
    //{
    //    PlaySound();
    //}

    void RepeatSound()
    {
        soundComponent.PlayOneShot(soundTrack);
    }
    void PlaySound()
    {
        soundComponent.PlayOneShot(soundTrack);
    }
}
