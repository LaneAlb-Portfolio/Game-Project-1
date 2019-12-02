using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBedRM1 : MonoBehaviour
{
    public Camera mainCamera;
    private Canvas floatingCanvas;
    private Animator anim;
    private AudioSource audioSource;
    public float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
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

            if (hit.collider.tag == "BedroomDoor1")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("Open");
                    audioSource.Play();
                    anim.Play("Bedroom1Door");
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
