using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public int maxClicks = 3;
    public float fadeDuration = 0.5f;
    public TextMeshProUGUI countText; // assign this variable to the Text element on your canvas

    private int currentClicks = 0;
    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;

        Color fadedColor = material.color;
        fadedColor.a = 1f;
        material.color = fadedColor;
    }

    private IEnumerator FadeOut()
    {
        Color fadedColor = material.color;

        for (float t = 0f; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            fadedColor.a = alpha;
            material.color = fadedColor;
            yield return null;
        }

        fadedColor.a = 0f;
        material.color = fadedColor;
        Destroy(gameObject);

        // Update the count text on the canvas
        currentClicks++;
        if (countText != null)
        {
            countText.text = "Wiped " + currentClicks.ToString() + "/" + maxClicks.ToString();
        }
    }

    private void OnMouseDown()
    {
        if (currentClicks < maxClicks)
        {
            StartCoroutine(FadeOut());
        }
    }
}