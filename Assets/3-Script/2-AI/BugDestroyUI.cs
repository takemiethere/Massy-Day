using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BugDestroyUI : MonoBehaviour
{
    public int bugsToDestroy = 3;
    public TextMeshProUGUI textbug;

    private int bugsDestroyed = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void BugDestroyed()
    {
        bugsDestroyed++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        textbug.text = "Kill " + bugsDestroyed + " / " + bugsToDestroy + " Cockroacs";
    }
}
