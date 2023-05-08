using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgOnOff : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    public void BgSoundOnOff()
    {
        AudioSource bgSound = music.GetComponent<AudioSource>();

        if (bgSound.mute == true)
        {
            bgSound.mute = false;
        }
        else
        {
            bgSound.mute = true;
        }
    }
}

