using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager instace;

    public AudioSource BgmAudio;
    public AudioSource SoundAudio;
    public AudioSource WeatherAudio;

    public Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if(instace == null)
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
            Setting();
        } else
        {
            Destroy(gameObject);
        }
    }

    void Setting()
    {
        BgmAudio = transform.GetChild(0).GetComponent<AudioSource>();
        SoundAudio = transform.GetChild(1).GetComponent<AudioSource>();
        WeatherAudio = transform.GetChild(2).GetComponent<AudioSource>();

        ClipSet();
    }

    void ClipSet()
    {
        AudioClip[] sfxs = Resources.LoadAll<AudioClip>("Sfx/");

        Debug.Log(sfxs.Length);

        foreach(AudioClip sfx in sfxs)
        {
            clips.Add(sfx.name, sfx);
        }
    }
    
    public void PlayBgm(string name)
    {
        if(!clips.Keys.Contains(name))
        {
            return;
        }

        AudioClip audio = clips[name];

        BgmAudio.clip = audio;
        BgmAudio.Play();
    }

    public void PlaySfx(string name)
    {
        if (!clips.Keys.Contains(name))
        {
            return;
        }

        AudioClip audio = clips[name];

        SoundAudio.PlayOneShot(audio);
    }
}
