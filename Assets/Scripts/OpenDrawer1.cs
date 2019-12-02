using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer1 : MonoBehaviour
{
    public Camera mainCamera;
    private Canvas floatingCanvas;
    private Animator anim;
    private AudioSource _audio;

    public float rayDistance;



    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Stop();
        floatingCanvas = GetComponentInChildren<Canvas>();
        anim = gameObject.GetComponent<Animator>();
        floatingCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Open();
    }

    void Open()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {

            if (hit.collider.tag == "Nightstand2")
            {
                floatingCanvas.enabled = true;

                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("Active");
                    _audio.Play();
                    anim.Play("NightstandAnim");
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
}
