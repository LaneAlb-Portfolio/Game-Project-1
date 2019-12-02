using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSounds : MonoBehaviour
{
    private AudioSource dogGrowl;
    //public float delay;
    

    void Start()
    {
        dogGrowl = GetComponent<AudioSource>();
        //dogGrowl.PlayDelayed(delay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dogGrowl.Play();
        }
    }
}
