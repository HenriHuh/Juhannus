using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource source;
    public static AudioManager instance;
    bool started = false;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        instance = this;
        StartCoroutine(WaitStart());
    }
    public void Play(AudioClip clip, float vol)
    {
        if (!started)
        {
            return;
        }

        source.PlayOneShot(clip, vol);
    }

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(1);
        started = true;
        yield return null;

    }
}
