using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.counter++;
        Destroy(gameObject);
    }

}
