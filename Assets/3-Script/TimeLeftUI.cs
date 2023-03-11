/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeftUI : MonoBehaviour
{
    public CleaningDestroy cleaningDestroy;  // Reference to the CleaningDestroy script attached to the same GameObject.

    private void Update()
    {
        float timeLeft = cleaningDestroy.GetClickTimer();

        // Display the time left using GUI or other UI methods.
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Time left: " + Mathf.RoundToInt(timeLeft));
    }
}*/