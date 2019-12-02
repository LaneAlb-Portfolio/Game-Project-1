using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireDamage : MonoBehaviour
{
    private GameObject _player;
    private AudioSource sizzle;

    private bool _playerTrigger = false;



    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        sizzle = GetComponent<AudioSource>();
        sizzle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerTrigger = true;
            sizzle.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerTrigger = false;
        }
    }

    void Update()
    {
        if (_playerTrigger == true)   
        {
            _player.GetComponent<PlayerHealth>().TakeDamage(25);
        }
    }


}
