using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPic : MonoBehaviour
{
    public GameObject pictureObject;
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.1f;

    private bool isPlayerNear;
    private GameObject monitoredObject;

    void Start()
    {
        // Get reference to monitored object
        monitoredObject = gameObject;
    }

    void Update()
    {
        // Check for player proximity
        if (isPlayerNear)
        {
            // Show picture
            pictureObject.SetActive(true);
        }
        else
        {
            // Hide picture
            pictureObject.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (isPlayerNear)
        {
            StartCoroutine(ShakePicture());
        }
    }

    IEnumerator ShakePicture()
    {
        float timeElapsed = 0f;
        Vector3 startPosition = pictureObject.transform.position;

        while (timeElapsed < shakeDuration)
        {
            // Calculate new position based on Perlin noise
            Vector3 newPosition = startPosition + Random.insideUnitSphere * shakeIntensity;
            newPosition.z = startPosition.z;

            // Update picture position
            pictureObject.transform.position = newPosition;

            // Wait for next frame
            yield return null;

            // Update elapsed time
            timeElapsed += Time.deltaTime;
        }

        // Reset picture position
        pictureObject.transform.position = startPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void OnDestroy()
    {
        // Destroy picture object when monitored object is destroyed
        Destroy(pictureObject);
    }
}
