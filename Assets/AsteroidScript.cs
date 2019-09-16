using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotationSpeed;
    public float minSpeed, maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        Asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Asteroid" && other.tag != "GameBoundary")
        {
            var targetHealth = other.GetComponent<CharacterHealth>();
            if(targetHealth != null)
            {
                targetHealth.TakeDamage(100);
            }
        }
    }
}
