using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTwoObjective : MonoBehaviour
{
    private Text objective;

    private void Awake()
    {
        objective = GetComponent<Text>();
        objective.text = "Objective - Find and Exit Through the Door";
    }

}
