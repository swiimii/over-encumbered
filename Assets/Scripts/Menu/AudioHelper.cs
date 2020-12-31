using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHelper : MonoBehaviour
{
    public AudioMixer mixer;
    public string audioGroup;
    public void SetValue(float sliderValue)
    {
        mixer.SetFloat(audioGroup, Mathf.Log10(sliderValue)*20);
    }
}
