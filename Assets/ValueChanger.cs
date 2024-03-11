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
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            libPdInstance.SendMessage("clipLocation", PlaySound(audioClip));
        }

        libPdInstance.SendFloat("clipSpeed", clipSpeed);
        libPdInstance.SendFloat("clipVolume", clipVolume);
        libPdInstance.SendFloat("clipHighPass", clipHighPass);
        libPdInstance.SendFloat("clipLowPass", clipLowPass);
        libPdInstance.SendFloat("clipFreq", clipFreq);
    }

    public string PlaySound(AudioClip _audioClip)
    {
        string dataPatch = Application.dataPath;
        dataPatch = dataPatch.Substring(0, dataPatch.Length - 6);
        string clipLocation = dataPatch + AssetDatabase.GetAssetPath(_audioClip.GetInstanceID());
        //libPdInstance.SendMessage("clipLocation", PlaySound(audioClip));
        return clipLocation;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DrumStick"))
        {
            libPdInstance.SendMessage("clipLocation", PlaySound(audioClip));
        }
    }
}
