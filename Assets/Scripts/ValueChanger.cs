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

    private void Update()
    {
        libPdInstance.SendFloat("clipSpeed", clipSpeed);
        libPdInstance.SendFloat("clipVolume", clipVolume);
        libPdInstance.SendFloat("clipHighPass", clipHighPass);
        libPdInstance.SendFloat("clipLowPass", clipLowPass);
        libPdInstance.SendFloat("clipFreq", clipFreq);
    }

    public void DrumHit(float velocity)
    {
        clipVolume = velocity / 100f;
        libPdInstance.SendMessage("clipLocation", PlaySound(audioClip));
    }

    public string PlaySound(AudioClip _audioClip)
    {
        string dataPatch = Application.dataPath;
        dataPatch = dataPatch.Substring(0, dataPatch.Length - 6);
        string clipLocation = dataPatch + "Assets/Sounds/" + audioClip.name + ".wav";
        return clipLocation;
    }
}
