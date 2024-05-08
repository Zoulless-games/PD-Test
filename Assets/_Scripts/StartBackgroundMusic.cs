using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBackgroundMusic : MonoBehaviour
{
    public float timeBeforeMusicStarts;
    public AudioSource musicSource;

    void Start()
    {
        //musicSource.PlayDelayed(timeBeforeMusicStarts);
    }
}
