using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenL3Door : MonoBehaviour
{
    public Camera mainCamera;
    public Canvas floatingCanvas;
    public Canvas lockedCanvas;
    public GameObject winScreen;
    public GameObject player;

    public float rayDistance;
    private bool winGame = false;

    public L3Key2 l3Key;

    void Start()
    {
        floatingCanvas.enabled = false;
        lockedCanvas.enabled = false;
    }

    void Update()
    {
        Open();
        YouWin();
    }

    void Open()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "Door" && l3Key.finalKey == false)
            {
                lockedCanvas.enabled = true;
            }
            if (hit.collider.tag == "Door" && l3Key.finalKey == true)
            {
                Destroy(lockedCanvas);
                floatingCanvas.enabled = true;
            }
            //else
            //{
            //    floatingCanvas.enabled = true;
            //}
            if (hit.collider.tag == "Door" && Input.GetMouseButtonDown(0) && l3Key.finalKey == true)
            {
                winGame = true;
            }
            //else
            //{
            //    floatingCanvas.enabled = false;
            //}
        }
    }
    void YouWin()
    {
        if (winGame == false)
        {
            return;
        }
        if (winGame == true)
        {
            winScreen.SetActive(winGame);
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
