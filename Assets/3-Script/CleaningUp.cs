/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CleaningUp : MonoBehaviour
{

    public float maxStealDistance = 5f; // maximum distance player can clean from
    public float cleanTime = 5f; // time required to clean the object
    public GameObject cleanObject; // the clean object to be spawned
    public float spawnDistance = 2f; // distance in front of the player to spawn the clean object

    private bool isCleaning = false;
    private float timeLeft = 0f;

    void Update()
    {
        // Check if the player is close to the dirty object and holding down the "E" key
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (Input.GetKey(KeyCode.E) && !isCleaning && distance <= maxStealDistance)
        {
            isCleaning = true;
            timeLeft = cleanTime;
        }

        // Check if the player has stopped holding down the "E" key
        if (isCleaning && !Input.GetKey(KeyCode.E))
        {
            isCleaning = false;
            timeLeft = 0f;
            return;
        }

        if (isCleaning)
        {
            // Update the cleaning timer
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                // Calculate the direction from the player to the dirty object
                Vector3 direction = (transform.position - Camera.main.transform.position).normalized;

                // Calculate a position in front of the player to spawn the clean object
                Vector3 spawnPosition = transform.position + direction * spawnDistance;

                // Instantiate the clean object at the spawn position and set its parent to the player
                GameObject newCleanObject = Instantiate(cleanObject, spawnPosition, Quaternion.identity);
                newCleanObject.transform.parent = transform;
                Destroy(gameObject);

            }
        }
    }

    private void OnGUI()
    {
        if (isCleaning)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Cleaning: " + Mathf.RoundToInt(timeLeft));
        }
    }
}
*/