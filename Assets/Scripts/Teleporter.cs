using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform target;
    public GameObject guide;
    public GameObject key;
    public AudioClip clip;
    private IEnumerator coroutine;

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.collider.gameObject.tag == "teleporter" && guide.transform.childCount >= 1)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            coroutine = Teleport();
            StartCoroutine(coroutine);
            //transform.position = target.position;
            //transform.rotation = target.rotation;
            Destroy(key);

        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1f);
        transform.position = target.position;
        transform.rotation = target.rotation;
    }




}
