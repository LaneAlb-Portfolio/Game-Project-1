using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEndTable : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas floatingCanvasTop;
    public Canvas floatingCanvasBottom;
    public Canvas locked;
    public Animator anim;
    public Animator anim2;
    public Collider top;
    public GameObject topText;
    public GameObject bottomText;
    private AudioSource drawerSound;

    public float rayDistance;
    public bool anim1 = false;

    // Start is called before the first frame update
    void Start()
    {
        drawerSound = GetComponent<AudioSource>();
        drawerSound.Stop();
        floatingCanvasTop.enabled = false;
        floatingCanvasBottom.enabled = false;
        locked.enabled = false;
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
                Debug.Log("bottom");
                floatingCanvasBottom.enabled = true;
                //Debug.Log("Hit");

                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(bottomText);
                    anim.SetTrigger("BottomDrawer");
                    drawerSound.Play();
                    anim.Play("BottomDrawerAnim");
                    floatingCanvasTop.enabled = false;
                    anim1 = true;
                }
                
            }
            if (hit.collider.tag == "EndTable2")
            {
                Debug.Log("top");
                if (anim1 == false)
                {
                    locked.enabled = true;
                }
                else if (anim1 == true)
                {
                    locked.enabled = false;
                    floatingCanvasTop.enabled = true;
                }

                if (anim1 == true && Input.GetMouseButtonDown(0))
                {
                    anim2.SetTrigger("TopDrawer");
                    drawerSound.Play();
                    anim2.Play("TopDrawerAnim");
                    Destroy(topText);
                    top.enabled = false;
                }
                
            }
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("Found Player");
    //        floatingCanvas.enabled = true;
    //        canOpen = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        floatingCanvas.enabled = false;
    //    }
    //}
}
