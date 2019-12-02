using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveText : MonoBehaviour
{
    public Text objective;
    public GameObject guide;
    //public GameObject topOfVolcano;
    

    private void Awake()
    {
        objective.text = "Objective - Find The Key";
    }

    private void Update()
    {
        CheckObjective();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("TopOfVolcano"))
    //    {
    //        objective.text = "Objective - Jump Into The Volcano";            
    //    }
    //}

    void CheckObjective()
    {
        if (guide.transform.childCount >= 1)
        {
            objective.text = " Objective - Find and Enter The Gate";
        }
    }
}
