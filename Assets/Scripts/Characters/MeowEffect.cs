using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MeowEffect : MonoBehaviour
{
    public List<AudioClip> meows;

    public void PlaySound()
    {
        var soundIndex = (int)(Random.value*meows.Count);
        var src = GetComponent<AudioSource>();
        src.clip = meows[soundIndex];
        src.Play();
    }
}
