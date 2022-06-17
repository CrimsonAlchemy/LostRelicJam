using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource birdTakingOff_SFX;
    public AudioSource feetsteps_SFX;
    public AudioSource heartbeat_SFX;
    public AudioSource shadowAttack_SFX;
    public AudioSource shadowDeath_SFX;

    public bool isWalking;
    bool hasPlayedClip = false;

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
        if (!heartbeat_SFX.isPlaying)
        {
            heartbeat_SFX.Play();
        }
    }
    public void StopHeartbeat()
    {
        heartbeat_SFX.Stop();
    }

    public void StopFeetsteps()
    {
        feetsteps_SFX.Stop();
    }
    public void PlayFootsteps()
    {
        hasPlayedClip = true;
        if (!feetsteps_SFX.isPlaying && isWalking)
        {
            //feetsteps_SFX.pitch = Random.Range(0.3f, 1.1f);
            //TODO 0.65 is a good pitch speed for animations as they are currently. Can change when animations change.
            feetsteps_SFX.volume = 0.2f;
            if (hasPlayedClip)
            {
                feetsteps_SFX.Play();
            }
            else
            {
                feetsteps_SFX.Play();
            }
        }
        if (!isWalking)
        {
            feetsteps_SFX.volume = 0;
            feetsteps_SFX.Pause();
        }
    }

    public void PlayShadowAttack()
    {
        shadowAttack_SFX.time = .6f;
        shadowAttack_SFX.Play();
    }

    public void PlayShadowDeath()
    {
        shadowDeath_SFX.Play();
    }

}
