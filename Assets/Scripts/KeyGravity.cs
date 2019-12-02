using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGravity : MonoBehaviour
{

    private Rigidbody rb;
    public Transform guide;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (guide.childCount <= 0)
        {
            rb.isKinematic = false;
        }

        if (guide.childCount >= 1)
        {
            rb.isKinematic = true;
        }
    }
}
