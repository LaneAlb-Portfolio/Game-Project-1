using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleDamage : MonoBehaviour
{
    private GameObject _player;
    private bool _playerTrigger = false;
    private float damage = 15;
    private Collider _collider;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerTrigger = true;
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
            _player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
