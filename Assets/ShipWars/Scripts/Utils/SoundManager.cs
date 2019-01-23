using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public virtual AudioSource PlaySound(AudioClip sfx, Vector3 location, bool loop = false)
    {
        GameObject temporaryAudioHost = new GameObject("[TempAudio] " + sfx.name);
        temporaryAudioHost.transform.position = location;
        AudioSource audioSource = temporaryAudioHost.AddComponent<AudioSource>() as AudioSource;
        audioSource.clip = sfx;
        audioSource.loop = loop;
        audioSource.Play();

        if (!loop)
        {
            Destroy(temporaryAudioHost, sfx.length);
        }

        return audioSource;
    }

    public virtual void StopSound(AudioSource source)
    {
        if (source != null)
        {
            Destroy(source.gameObject);
        }
    }
}
