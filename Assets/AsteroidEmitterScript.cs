using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{
    public GameObject[] Asteroids = new GameObject[3];

    public float minDelay, maxDelay;
    private float nextLaunch;
    void Update()
    {
        if(Time.time > nextLaunch)
        {
            int randomAsteroidNumber = Random.Range(1, 3);
            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);
            Instantiate(
                Asteroids[randomAsteroidNumber],
                new Vector3(
                    Random.Range(-transform.localScale.x/2, transform.localScale.x/2),
                    transform.position.y,
                    transform.position.z),
                Quaternion.identity);
        }
    }
}
