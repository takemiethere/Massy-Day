using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNoti : MonoBehaviour
{
    public GameObject pictureObject;
    public float minDistance = 1f;

    private bool isPlayerNear;

    void Update()
    {
        // Check for player proximity
        if (isPlayerNear && Vector3.Distance(transform.position, Camera.main.transform.position) > minDistance)
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
            // Do nothing, shaking is removed
        }
        else
        {
            // Hide picture when player is not near
            pictureObject.SetActive(false);
        }
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