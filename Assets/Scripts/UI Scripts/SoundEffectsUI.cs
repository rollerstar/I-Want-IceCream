using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsUI : MonoBehaviour
{
    [SerializeField]
    AudioSource SFXSource;
    [SerializeField]
    AudioClip clip;
    public void OnClick()
    {
        SFXSource.clip = clip;
        SFXSource.Play();
    }
}
