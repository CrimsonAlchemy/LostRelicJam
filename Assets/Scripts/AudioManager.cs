using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource birdTakingOff_SFX;
    public AudioSource feetsteps_SFX;
    public AudioSource heartbeat_SFX;

    public bool isWalking;

    private void Awake()
    {
        instance = this;
    }

    public void PlayBirdSound()
    {
        birdTakingOff_SFX.Play();
    }

    public void PlayHeartbeat()
    {
        heartbeat_SFX.Play();
    }

    public void PlayFootsteps()
    {
        if (!feetsteps_SFX.isPlaying && isWalking)
        {
            //feetsteps_SFX.pitch = Random.Range(0.3f, 1.1f);
            //TODO 0.65 is a good pitch speed for animations as they are currently. Can change when animations change.
            feetsteps_SFX.Play();
        }
        if (!isWalking)
        {
            feetsteps_SFX.Stop();
        }
    }
}
