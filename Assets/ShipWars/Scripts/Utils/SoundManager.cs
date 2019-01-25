using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    /// <summary>
    /// Permette di attivare un suono, creando una sorgente audio temporanea (se non è in loop)
    /// oppure permanente (se in loop)
    /// </summary>
    public virtual AudioSource PlaySound(AudioClip sfx, Vector3 location, bool loop = false)
    {
        // Crea un gameobject e gli associa un componente AudioSource
        GameObject temporaryAudioHost = new GameObject("[TempAudio] " + sfx.name);
        temporaryAudioHost.transform.position = location;
        AudioSource audioSource = temporaryAudioHost.AddComponent<AudioSource>() as AudioSource;
        audioSource.clip = sfx;
        audioSource.loop = loop;
        audioSource.Play();

        // Se non è un loop, programma la distruzione
        if (!loop)
        {
            Destroy(temporaryAudioHost, sfx.length);
        }

        return audioSource;
    }

    /// <summary>
    /// Ferma l'audio, distruggendo il gameobject corrispondente
    /// </summary>
    public virtual void StopSound(AudioSource source)
    {
        if (source != null)
        {
            Destroy(source.gameObject);
        }
    }
}
