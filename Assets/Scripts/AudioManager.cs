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
    public AudioSource outro_Music;

    public GameObject outroMusic_GO;

    public bool isWalking;
    bool hasPlayedClip = false;

    private void Awake()
    {
        instance = this;
    }

    public void PlayOutroMusic()
    {
        outroMusic_GO.SetActive(true);
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
        //hasPlayedClip = true;
        if (!feetsteps_SFX.isPlaying && isWalking)
        {
            //feetsteps_SFX.pitch = Random.Range(0.3f, 1.1f);
            //TODO 0.65 is a good pitch speed for animations as they are currently. Can change when animations change.
            //feetsteps_SFX.volume = 0.3f;
            //if (hasPlayedClip)
            //{
            //    feetsteps_SFX.Play();
            //}
            //else
            //{
                feetsteps_SFX.Play();
            //}
        }
        if (!isWalking)
        {
            //feetsteps_SFX.volume = 0;
            feetsteps_SFX.Stop();
        }
    }

    bool hasPlayedShadowAttack = false;
    public void PlayShadowAttack()
    {
        if (!shadowAttack_SFX.isPlaying && !hasPlayedShadowAttack)
        {
            shadowAttack_SFX.time = .6f;
            shadowAttack_SFX.Play();
            hasPlayedShadowAttack = true;
        }
    }

    bool hasPlayedShadowDeath = false;
    public void PlayShadowDeath()
    {
        if (!shadowDeath_SFX.isPlaying && !hasPlayedShadowDeath)
        {
            shadowDeath_SFX.Play();
            hasPlayedShadowDeath = true;
        }
    }

}
