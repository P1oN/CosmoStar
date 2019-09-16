using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public int dmgAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "GameBoundary" && other.tag != "Player" && other.tag != "Bullet")
        {
            var targetHealth = other.GetComponent<CharacterHealth>();
            if(targetHealth != null)
            {
                targetHealth.TakeDamage(dmgAmount);
            }
            Destroy(gameObject);
        }
    }
}
