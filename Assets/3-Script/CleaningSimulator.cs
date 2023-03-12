using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CleaningSimulator : MonoBehaviour

{
    public float cleanTime = 5f;
    public float maxCleanDistance = 2f;
    public GameObject dirtyObjectPrefab;
    public GameObject cleanObjectPrefab;
    public Transform dirtyObjectsParent;
    public Transform cleanObjectsParent;
    public Transform binTransform;
    public TextMeshProUGUI cleaningProgressText;

    private float timeLeft = 0f;
    private bool isCleaning = false;
    private bool isHoldingDirtyObject = false;
    private bool isNearBin = false;
    private GameObject dirtyObjectObj;
    private GameObject cleanObjectObj;
    private int numCleaned = 0;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        if (Input.GetKey(KeyCode.E) && !isCleaning && distance <= maxCleanDistance)
        {
            isCleaning = true;
            timeLeft = cleanTime;
        }

        if (isCleaning && !Input.GetKey(KeyCode.E))
        {
            isCleaning = false;
            timeLeft = 0f;
            return;
        }

        if (isCleaning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                // Spawn clean object and destroy dirty object
                cleanObjectObj = Instantiate(cleanObjectPrefab, dirtyObjectObj.transform.position, dirtyObjectObj.transform.rotation, cleanObjectsParent);
                Destroy(dirtyObjectObj);

                // Increment numCleaned and update progress text
                numCleaned++;
                cleaningProgressText.text = "Cleaning " + numCleaned.ToString() + " of 10 objects";

                // Check if all objects have been cleaned and display win message
                if (numCleaned >= 10)
                {
                    cleaningProgressText.text = "You win!";
                }

                isHoldingDirtyObject = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isHoldingDirtyObject)
            {
                // Drop dirty object
                dirtyObjectObj.transform.parent = dirtyObjectsParent;
                isHoldingDirtyObject = false;
            }
            else if (isNearBin && !isCleaning)
            {
                // Pick up nearest dirty object
                float closestDistance = float.MaxValue;
                GameObject closestObject = null;
                foreach (Transform child in dirtyObjectsParent)
                {
                    float dist = Vector3.Distance(transform.position, child.position);
                    if (dist < closestDistance)
                    {
                        closestDistance = dist;
                        closestObject = child.gameObject;
                    }
                }
                if (closestObject != null && closestDistance <= maxCleanDistance)
                {
                    dirtyObjectObj = closestObject;
                    dirtyObjectObj.transform.parent = transform;
                    dirtyObjectObj.transform.localPosition = Vector3.zero;
                    isHoldingDirtyObject = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == binTransform)
        {
            isNearBin = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == binTransform)
        {
            isNearBin = false;
        }
    }
}
