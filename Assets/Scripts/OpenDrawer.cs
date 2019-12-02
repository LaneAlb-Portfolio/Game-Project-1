using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas floatingCanvas;
    public Canvas lockedCanv;
    private Animator anim;
    public GameObject guide;
    public GameObject firstKey;
    public GameObject textbox;
    private AudioSource _audio;

    public float rayDistance;

    

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Stop();
        //floatingCanvas = GetComponentInChildren<Canvas>();
        anim = gameObject.GetComponent<Animator>();
        floatingCanvas.enabled = false;
        lockedCanv.enabled = false;
        
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
            if (hit.collider.tag == "Nightstand1" && guide.transform.childCount == 0)
            {
                Debug.Log("Locked");
                lockedCanv.enabled = true;
            }
            else
            {
                lockedCanv.enabled = false;
            }
            if (hit.collider.tag == "Nightstand1" && guide.transform.childCount == 1)
            {
                floatingCanvas.enabled = true;

                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetTrigger("Open");
                    _audio.Play();
                    anim.Play("Nightstand1Anim");
                    floatingCanvas.enabled = false;
                    Destroy(firstKey);
                    Destroy(textbox);


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
