using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Camera mainCamera;

    public float rayDistance;

    public Canvas floatingCanvas;

    private void Start()
    {
        floatingCanvas.enabled = false;
    }

    private void Update()
    {
        Open();
    }

    void Open()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "Door")
            {
                floatingCanvas.enabled = true;

                if (Input.GetMouseButtonDown(0))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
