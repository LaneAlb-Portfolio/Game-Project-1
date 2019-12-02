using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{ 
public Camera mainCamera;
private Rigidbody keyRb;
public Transform guide;

public float rayDistance;
public float distance;

public Canvas floatingCanvas;

void Start()
{
    floatingCanvas.enabled = false;
    keyRb = GetComponent<Rigidbody>();
}

void Update()
{
    Pickup();

    if (Input.GetMouseButtonDown(1))
    {
        Drop();
    }


}

void Pickup()
{
    RaycastHit hit;
    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out hit, rayDistance))
    {
        if (hit.collider.tag == "Key")
        {
            floatingCanvas.enabled = true;

            if (Input.GetMouseButtonDown(0))
            {
                transform.SetParent(guide);
                transform.localRotation = transform.rotation;
                transform.position = guide.position;
                floatingCanvas.enabled = false;
            }

        }
        else
        {
            floatingCanvas.enabled = false;
            return;

        }
    }
}

void Drop()
{
    gameObject.GetComponent<Collider>().enabled = true;

    if (guide.transform.childCount > 0)
    {
        guide.GetChild(0).parent = null;
        keyRb.useGravity = true;
    }
}
}
