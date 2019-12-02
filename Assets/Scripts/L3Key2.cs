using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Key2 : MonoBehaviour
{
    public Camera mainCamera;
    private Canvas floatingCanvas;
    private Animator anim;
    public GameObject text;

    public Transform guide;

    public bool finalKey = false;

    public float rayDistance;
    // Start is called before the first frame update
    void Start()
    {
        floatingCanvas = GetComponentInChildren<Canvas>();
        floatingCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pickup();
    }

    void Pickup()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "L3SecondKey")
            {
                floatingCanvas.enabled = true;

                if (Input.GetMouseButtonDown(0))
                {
                    transform.SetParent(guide);
                    transform.localRotation = transform.rotation;
                    transform.position = guide.position;
                    floatingCanvas.enabled = false;
                    finalKey = true;
                    Destroy(text);
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
