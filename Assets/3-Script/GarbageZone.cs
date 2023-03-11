/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cleaning cleaningScript = other.GetComponent<Cleaning>();
            if (cleaningScript != null && cleaningScript.isCarryingGarbage)
            {
                Destroy(cleaningScript.garbageBagsParent.gameObject);
                cleaningScript.SetIsCarryingGarbage(false);
            }
        }
    }

}*/