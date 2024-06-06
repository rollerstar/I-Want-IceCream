using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLogic : MonoBehaviour
{
    public float curSpeed, minSpeed, maxSpeed, rayLength = 2.5f;
    public GameManager manager;
    public bool canStop, otherCar;
    float timer = 5.0f;
    [SerializeField]
    GameObject crashParticle;
    void Start()
    {
        curSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(transform.forward * curSpeed * 2 * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {

        print("Collided with: " + collision.gameObject.tag);

        if(collision.gameObject.tag == "Player")
        {
            manager.CarHit();
        }
        
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            Instantiate(crashParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
