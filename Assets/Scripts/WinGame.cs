using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class WinGame : MonoBehaviour
{
    public GameObject player;
    public Image winScreen;
    //public Text score;
    public bool win;
    //public Image damageScreen;
    //public Canvas Canvas;
    //public Canvas all;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        //playerController = GetComponent<FirstPersonController>()       
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();
        //score.text = HealthUsed.count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            win = true;
            //damageScreen.enabled = false;
            //Canvas.enabled = false;
            //all.enabled = false;
            Debug.Log("You Win!");
        }
    }

    void CheckWin()
    {
        if (win == false)
        {
            return;
        }
        if (win == true)
        {
            winScreen.gameObject.SetActive(win);
            //GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
    }
}
