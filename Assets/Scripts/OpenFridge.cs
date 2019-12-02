using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFridge : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas floatingCanvasBottom;
    public Canvas topCanv;
    public Animator anim;
    public Animator anim2;
    public GameObject topText;
    public GameObject bottomText;

    public float rayDistance;
    //public bool bottomOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        topCanv.enabled = false;
        floatingCanvasBottom.enabled = false;
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

            if (hit.collider.tag == "Fridge")
            {
                floatingCanvasBottom.enabled = true;

                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("BigDoorOpen");
                    anim.Play("Fridge");
                    bottomText.SetActive(false);
                }
            }
            else
            {
                floatingCanvasBottom.enabled = false;
            }
         
            if (hit.collider.tag == "FridgeSmallDoor")
            {
                topCanv.enabled = true;

                if (Input.GetMouseButtonDown(0))
                {
                    anim2.SetTrigger("LittleDoor");
                    anim2.Play("Fridge2");
                    topText.SetActive(false);
                }
            }
            else
            {
                topCanv.enabled = false;
            }
        }
    }   
}
