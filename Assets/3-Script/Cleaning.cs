using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour
{
    //public QuestManager questManager;
    public float cleanTime = 5f;
    public float maxCleanDistance = 2f;
    public GameObject garbageBagsPrefab;
    public GameObject targetZoneObject;
    public Transform garbageBagsParent; // Added reference to empty game object as parent for garbage bags object
    private float timeLeft = 0f;
    private bool isCleaning = false;
    private bool isCarryingGarbage = false;

    /*void Start()
    {
        questManager = GameObject.FindObjectOfType<QuestManager>();
    }
    */
    void Update()
    {
        Debug.Log("Update() called.");
        // Check if the player is close to the dirty object and holding down the "E" key
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (Input.GetKey(KeyCode.E) && !isCleaning && distance <= maxCleanDistance)
        {
            isCleaning = true;
            timeLeft = cleanTime;
            // Disable player movement while cleaning
            GetComponent<Rigidbody>().isKinematic = true;
        }

        // Check if the player has stopped holding down the "E" key
        if (isCleaning && !Input.GetKey(KeyCode.E))
        {
            isCleaning = false;
            timeLeft = 0f;
            // Re-enable player movement
            GetComponent<Rigidbody>().isKinematic = false;
            return;
        }

        if (isCleaning)
        {
            // Update the cleaning timer
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                // Spawn garbage bags object as child of player and switch to carrying garbage mode
                GameObject garbageBagsObj = Instantiate(garbageBagsPrefab, garbageBagsParent);
                garbageBagsObj.transform.localPosition = Vector3.zero; // Set local position of garbage bags object to zero
                isCarryingGarbage = true;
                // Destroy the dirty object
                Destroy(gameObject);
            }
        }

        /*   if (Input.GetKeyDown(KeyCode.F) && isCarryingGarbage)
           {
               // Check if the player is inside the target zone
               float distanceToTargetZone = Vector3.Distance(transform.position, targetZoneObject.transform.position);
               if (distanceToTargetZone <= maxCleanDistance)
               {
                   // Get the garbage bags object from the parent transform
                   GameObject garbageBagsObj = garbageBagsParent.GetChild(0).gameObject;
                   // Delete the garbage bags object
                   Destroy(garbageBagsObj);
                   isCarryingGarbage = false;
               }
           }*/

    }

    /*private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter() called.");
            // Check if the player is carrying garbage and has entered the target zone
            if (isCarryingGarbage && other.CompareTag("TargetZone"))
            {
            // Change to carrying nothing mode
            //Destroy(Instantiate(garbageBagsParent.gameObject));
            //Destroy("trash bag(Clone)");
            isCarryingGarbage = false;
            }
        }*/

    /*   public void SetIsCarryingGarbage(bool carryingGarbage)
       {
           isCarryingGarbage = carryingGarbage;
       }*/

    private void OnGUI()
    {
        if (isCleaning)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Cleaning: " + Mathf.RoundToInt(timeLeft));
        }
        else if (isCarryingGarbage)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Carrying garbage");
        }

        // Draw the target zone
        /*Vector3 targetZoneScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        float targetZoneSize = maxCleanDistance * 2 * Screen.height / Camera.main.fieldOfView;
        Rect targetZoneRect = new Rect(targetZoneScreenPosition.x - targetZoneSize / 2, Screen.height - targetZoneScreenPosition.y - targetZoneSize / 2, targetZoneSize, targetZoneSize);
        GUI.Box(targetZoneRect, "Target Zone");*/
    }

}