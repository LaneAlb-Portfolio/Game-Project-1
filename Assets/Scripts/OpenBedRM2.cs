using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBedRM2 : MonoBehaviour
{
    public Camera mainCamera;
    private Canvas floatingCanvas;
    private Animator anim;
    public float rayDistance;
    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Stop();
        floatingCanvas = GetComponentInChildren<Canvas>();
        anim = GetComponent<Animator>();
        floatingCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Open();
    }

    public void Open()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "BedroomDoor2")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("Open");
                    _audio.Play();
                    anim.Play("Bedroom2Door");
                }
                else
                {
                    return;
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        floatingCanvas.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        floatingCanvas.enabled = false;
    }
}
