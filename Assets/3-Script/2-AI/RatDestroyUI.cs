using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RatDestroyUI : MonoBehaviour
{
    public int ratsToDestroy = 3;
    public TextMeshProUGUI text;

    private int ratsDestroyed = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void RatDestroyed()
    {
        ratsDestroyed++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = "Kill " + ratsDestroyed + " / " + ratsToDestroy + " Rats.";
    }
}
