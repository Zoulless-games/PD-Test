using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ValueChanger : MonoBehaviour
{
    public LibPdInstance libPdInstance;

    public float clipSpeed;
    public float clipVolume;
    public float clipHighPass;
    public float clipLowPass;
    public float clipFreq;
    public AudioClip audioClip;

    private void Start()
    {
        UpdateAudioFile(audioClip);
    }

    private void Update()
    {
        libPdInstance.SendFloat("clipSpeed", clipSpeed);
        libPdInstance.SendFloat("clipVolume", clipVolume);
        libPdInstance.SendFloat("clipHighPass", clipHighPass);
        libPdInstance.SendFloat("clipLowPass", clipLowPass);
        libPdInstance.SendFloat("clipFreq", clipFreq);
    }

    public void UpdateAudioFile(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        libPdInstance.Update();
    }

    public void DrumHit(float velocity)
    {
        clipVolume = velocity / 100f;
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
