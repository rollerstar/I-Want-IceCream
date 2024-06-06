using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource sourceSFX, sourceMusic;
    
    public void CheckSFX()
    {
        if (PlayerPrefs.GetInt("SFX") == 0)
        {
            sourceSFX.volume = 1.0f;
        }   
        else
        {
            sourceSFX.volume = 0f;
        }
    }

    public void CheckMusic()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            sourceMusic.volume = 1.0f;
        }
        else
        {
            sourceMusic.volume = 0f;
        }
    }
}
