using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ValueChanger : MonoBehaviour
{
    public int index;

    public float clipVolume;
    public AudioClip audioClip;
    public GameObject hitParticle;
    public Material drumColor;
    public GameObject note;
    public GameObject drumColorObj;

    private void Start()
    {
        drumColorObj.GetComponent<Renderer>().material = drumColor;
    }

    public void UpdateAudioFile(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
    }

    public void DrumHit(float velocity)
    {
        clipVolume = velocity / 100f;
        GetComponent<AudioSource>().PlayOneShot(audioClip);
        GameObject particle = Instantiate(hitParticle);
        particle.transform.position = transform.position + new Vector3(0, 0.05f, 0);
        particle.GetComponent<ParticleSystemRenderer>().material = drumColor;
    }
}
