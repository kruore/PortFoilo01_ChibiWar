using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GM_SoundManager : MySingleton<GM_SoundManager>
{
    public AudioClip playAudioSouces;
    public AudioSource _audio;

    private void Awake()
    {S
        _audio = gameObject.AddComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
