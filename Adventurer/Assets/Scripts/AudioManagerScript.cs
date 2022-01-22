using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    
    public static AudioClip HeroAttackSound, HeroDeathSound, HeroBlockSound, BanditHitSound, BanditDeathSound, ButtonSound, ShopButtonSound;
    static AudioSource audioSource;

    void Start ()
    {
        HeroAttackSound = Resources.Load<AudioClip> ("Attack");
        HeroDeathSound = Resources.Load<AudioClip> ("Death");
        HeroBlockSound = Resources.Load<AudioClip> ("Block");
        BanditHitSound = Resources.Load<AudioClip> ("BanditHit");
        BanditDeathSound = Resources.Load<AudioClip> ("BanditDeath");
        ButtonSound = Resources.Load<AudioClip> ("Button");
        ShopButtonSound = Resources.Load<AudioClip> ("ShopButton");

        audioSource = GetComponent<AudioSource>();
    }
    public static void PlaySound (string sound)
    {
        switch(sound) {
            case "Attack":
                audioSource.PlayOneShot (HeroAttackSound);
                break;
            case "Death":
                audioSource.PlayOneShot (HeroDeathSound);
                break;
            case "Block":
                audioSource.PlayOneShot (HeroBlockSound);
                break;
            case "BanditHit":
                audioSource.PlayOneShot (BanditHitSound);
                break;
            case "BanditDeath":
                audioSource.PlayOneShot (BanditDeathSound);
                break;
            case "Button" :
                audioSource.PlayOneShot (ButtonSound);
                break;
            case "ShopButton" :
                audioSource.PlayOneShot (ShopButtonSound);
                break;


        }
    }

   // public static void PlayButton ()
   // {
   //     audioSource.PlayOneShot (ButtonSound);
    //}
    
}
