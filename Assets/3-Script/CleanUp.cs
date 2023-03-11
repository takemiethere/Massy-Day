/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public float cleanTime = 5f;
    public float maxCleanDistance = 2f;
    public GameObject garbageBagPrefab;
    public Transform garbageBagSpawnPoint;
    public Transform garbageTargetZone;
    private float timeLeft = 0f;
    private bool isCleaning = false;
    private bool holdingGarbageBag = false;

    void Update()
    {
        // Check if the player is close to the dirty thing and holding down the "E" key
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (Input.GetKey(KeyCode.E) && !isCleaning && distance <= maxCleanDistance)
        {
            isCleaning = true;
            timeLeft = cleanTime;
            StartCoroutine(DisablePlayerMovement());
        }

        // Check if the player has stopped holding down the "E" key
        if (isCleaning && !Input.GetKey(KeyCode.E))
        {
            isCleaning = false;
            timeLeft = 0f;
            StopCoroutine(DisablePlayerMovement());
            return;
        }

        if (isCleaning)
        {
            // Update the cleaning timer
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                holdingGarbageBag = true;
                Instantiate(garbageBagPrefab, garbageBagSpawnPoint.position, Quaternion.identity);
                isCleaning = false;
                timeLeft = 0f;
                StopCoroutine(DisablePlayerMovement());
            }
        }

        if (holdingGarbageBag && Input.GetKeyDown(KeyCode.E))
        {
            holdingGarbageBag = false;
            Destroy(GameObject.FindGameObjectWithTag("GarbageBag"));
        }

        if (holdingGarbageBag && Input.GetKeyDown(KeyCode.F))
        {
            Vector3 dropPosition = garbageTargetZone.position;
            Destroy(GameObject.FindGameObjectWithTag("GarbageBag"));
            // Add code to handle scoring or other actions related to successfully dropping the garbage bag
        }
    }

    IEnumerator DisablePlayerMovement()
    {
        yield return new WaitForSeconds(cleanTime);
        isCleaning = false;
        timeLeft = 0f;
    }

    private void OnGUI()
    {
        if (isCleaning)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Cleaning: " + Mathf.RoundToInt(timeLeft));
        }
        else if (holdingGarbageBag)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Holding garbage bag");
        }
    }
}
*/