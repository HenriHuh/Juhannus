using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource magicLoop;

    AudioSource source;
    public static AudioManager instance;
    bool started = false;

    bool magicPlaying;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        instance = this;
        StartCoroutine(WaitStart());
    }

    private void Update()
    {
        if (magicPlaying)
        {
            magicLoop.volume = Mathf.MoveTowards(magicLoop.volume, 0.25f, Time.deltaTime);
        }
        else
        {
            magicLoop.volume = Mathf.MoveTowards(magicLoop.volume, 0, Time.deltaTime * 0.5f);
        }
    }

    public void Play(AudioClip clip, float vol)
    {
        if (!started)
        {
            return;
        }

        source.PlayOneShot(clip, vol);
    }

    public void Magic(bool on)
    {
        magicPlaying = on;
    }

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(1);
        started = true;
        yield return null;

    }
}
