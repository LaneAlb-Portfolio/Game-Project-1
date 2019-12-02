using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBottomDrawer : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas floatingCanvas;
    public Animator anim;
    public Animator anim2;

    public float rayDistance;
    public bool anim1 = false;
    private bool canOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        //floatingCanvas = GetComponentInChildren<Canvas>();
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

            if (hit.collider.tag == "EndTable1")
            {
                //floatingCanvas.enabled = true;
                //Debug.Log("Hit");

                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("BottomDrawer");
                    anim.Play("BottomDrawerAnim");
                    //floatingCanvas.enabled = false;
                    anim1 = true;
                }
            }
            if (Input.GetMouseButtonDown(0) && anim1 == true && canOpen == true)
            {
                anim2.SetTrigger("TopDrawer");
                anim2.Play("TopDrawerAnim");
                floatingCanvas.enabled = false;
            }
            //else
            //{
            //    //floatingCanvas.enabled = false;
            //    return;
            //}
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Found Player");
            floatingCanvas.enabled = true;
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            floatingCanvas.enabled = false;
        }
    }
}
