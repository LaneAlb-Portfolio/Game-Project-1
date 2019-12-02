using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stovetopdamage : MonoBehaviour
{
    private GameObject _player;
    private bool _playerTrigger = false;
    private float damage = 5;

    private AudioSource sizzle;

    private void Start()
    {
        sizzle = GetComponent<AudioSource>();
        _player = GameObject.FindGameObjectWithTag("Player");
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
            sizzle.Stop();
        }
    }
    void Update()
    {
        if (_playerTrigger == true)
        {
            _player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
