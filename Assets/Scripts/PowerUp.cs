using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    AudioSource SFXsource;
    [SerializeField]
    AudioClip collectClip;
    public BoostManagement boostManager;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * 100, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            boostManager.BoostSpeed();
            //other.gameObject.GetComponent<FirstPersonAIO>().speed
            SFXsource.clip = collectClip;   
            SFXsource.Play();
            Destroy(gameObject);
        }
    }
}
