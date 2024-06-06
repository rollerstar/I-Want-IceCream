using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField]
    GameManager manager;
    [SerializeField]
    AudioSource sourceEffects;
    [SerializeField]
    AudioClip iceCreamClip;
    [SerializeField]
    Transform highlight;
    [SerializeField]
    float rayLength = 8;
    GameObject activeIC = null;
    
    void FixedUpdate()
    {
        //Too many if statements and debug draw rays for my liking, but she works so I ain't touching it.

        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        RaycastHit hit;

        Debug.DrawRay(ray.origin, Camera.main.transform.forward * rayLength, Color.cyan);

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.DrawRay(ray.origin, Camera.main.transform.forward * rayLength, Color.red);

            if (hit.collider.gameObject.name == "IceCream")
            {
                Debug.DrawRay(ray.origin, Camera.main.transform.forward * rayLength, Color.green);

                highlight = hit.transform.Find("HighlightMesh");
                highlight.gameObject.SetActive(true);
                activeIC = highlight.gameObject;

                if (Input.GetButton("Fire1"))
                {
                    sourceEffects.PlayOneShot(iceCreamClip);
                    Destroy(hit.collider.gameObject);
                    ++manager.iceCreams;
                    manager.CheckWin();
                }
            }

            else if (activeIC != null || hit.collider.name == null)
            {
                print("I see nothing@!");
                activeIC.SetActive(false);
                return;
            }
        }
    }
}