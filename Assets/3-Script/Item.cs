/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int maxClicks = 5;
    public float fadeDuration = 0.5f;

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
    }

    private void OnMouseDown()
    {
        if (currentClicks < maxClicks)
        {
            currentClicks++;
        }

        StartCoroutine(FadeOut());
    }
}
*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int maxClicks = 5;           // maximum number of clicks before object is destroyed
    public float fadeDuration = 0.5f;   // how long the material takes to fade
    public AnimationCurve fadeCurve;    // the curve that controls the fade effect

    private int currentClicks = 0;      // current number of clicks on the object
    private Material material;         // reference to the object's material
    private Color originalColor;        // the object's original color
    private Coroutine currentFade;      // reference to the current fade coroutine

    private void Start()
    {
        material = GetComponent<Renderer>().material;   // get the material component of the object
        originalColor = material.color;                 // store the object's original color
    }

    private void OnMouseDown()
    {
        if (currentClicks < maxClicks)
        {
            currentClicks++;

            // Stop any existing fade coroutine
            if (currentFade != null)
            {
                StopCoroutine(currentFade);
            }

            // Start a new fade coroutine
            currentFade = StartCoroutine(FadeMaterial());
        }
        else
        {
            Destroy(gameObject);   // destroy the object when maximum clicks are reached
        }
    }

    private IEnumerator FadeMaterial()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / fadeDuration;

            // Use an animation curve to control the fade effect
            float alpha = fadeCurve.Evaluate(progress);

            // Set the material color to a faded version of the original color
            Color fadedColor = originalColor;
            fadedColor.a = alpha;
            material.color = fadedColor;

            yield return null;
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    

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

            float progress = (fadeDuration - t) / fadeDuration;
           

            yield return null;
        }

        fadedColor.a = 0f;
        material.color = fadedColor;
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        StartCoroutine(FadeOut());
    }
}
