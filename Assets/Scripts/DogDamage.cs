using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDamage : MonoBehaviour
{
    private bool doDam = false;
    public GameObject player;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doDam == true)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doDam = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doDam = false;
        }
    }
}
