using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDamage : MonoBehaviour
{
    public float _damage = 15;
    private bool _hit;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_hit == true)
        {
            GetComponent<PlayerHealth>().TakeDamage(_damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Maze")
        {
            _hit = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Maze")
        {
            _hit = false;
        }
    }
}
