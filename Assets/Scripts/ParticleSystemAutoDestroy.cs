using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemAutoDestroy : MonoBehaviour
{
    ParticleSystem ps;
    [SerializeField]
    AudioSource SFXsource;
    [SerializeField]
    AudioClip crashClip;

    private IEnumerator Start()
    {
        SFXsource.clip = crashClip;
        SFXsource.Play();

        ps = GetComponent<ParticleSystem>();
        yield return new WaitForSeconds(ps.main.duration);
        Destroy(gameObject);
    }
}
