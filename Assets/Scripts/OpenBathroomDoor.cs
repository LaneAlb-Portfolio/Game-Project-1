using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBathroomDoor : MonoBehaviour
{
    public Camera mainCamera;
    private Canvas floatingCanvas;
    public Animator anim;
    public float rayDistance;
    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        floatingCanvas = GetComponentInChildren<Canvas>();
        floatingCanvas.enabled = false;
        _audio.Stop();
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
            if (hit.collider.tag == "BathroomDoor")
            {
                //Debug.Log("Hit da Door");
                if (Input.GetMouseButtonDown(0))
                {
                    //Debug.Log("clicked da door");
                    _audio.Play();
                    anim.SetTrigger("OpenDoor");
                    anim.Play("OpenBathroomDoor");
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
