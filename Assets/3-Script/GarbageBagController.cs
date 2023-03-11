/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GarbageBagController : MonoBehaviour
{
    public GameObject garbageBagObj; // the garbage bag object to control
    private bool isOpen = false; // flag to check if the garbage bag is open or closed

    void Start()
    {
        // close the garbage bag object by default
        isOpen = false;
        garbageBagObj.SetActive(false);
    }

    void Update()
    {
        // check if a cleaning object has been spawned
        if (GameObject.FindGameObjectWithTag("CleanObject") == null)
        {
            isOpen = true;
            garbageBagObj.SetActive(true);
        }
    }
}*/