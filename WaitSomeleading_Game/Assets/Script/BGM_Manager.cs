using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Manager : MonoBehaviour
{
    static public BGM_Manager instance;

    public AudioClip[] clips;

    private AudioSource source;

    public bool flag = false;

    private WaitForSeconds waitTime = new WaitForSeconds(0.007f);

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(int _playMusicTrack)
    {
        source.clip = clips[_playMusicTrack];
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void FadeOutMusic()
    {
        StartCoroutine(FadeOut());
    }

    public void FadeInMusic()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeOut()
    {
        for(float i = 0.4f; i >= 0f; i-= 0.001f)
        {
            source.volume = i;
            yield return waitTime;
        }
        flag = false;
    }

    IEnumerator FadeIn()
    {
        for (float i = 0.15f; i <= 0.4f; i+= 0.001f)
        {
            source.volume = i;
            yield return waitTime;
        }
        flag = true;
    }
}
