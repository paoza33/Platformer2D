﻿using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex;
    public static AudioManager instance;
    public AudioMixerGroup soundEffectMixer;
    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de AudioManager");
            return;
        }
        instance = this;
    }
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying){
            PlayNextSong();
        }
    }

    void PlayNextSong(){
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos){
        GameObject tempGO = new GameObject("tempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;
    }
}
