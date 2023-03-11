/*using UnityEngine;

public class TargetZone : MonoBehaviour
{
    [SerializeField] private Cleaning cleaningScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GarbageBag"))
        {
            if (cleaningScript.isCarryingGarbage)
            {
                GameObject garbageBag = other.gameObject;
                cleaningScript.AddGarbageBagToPile(garbageBag);
            }
            else
            {
                Debug.Log("Cleaning is not carrying garbage");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GarbageBag"))
        {
            GameObject garbageBag = other.gameObject;
            cleaningScript.RemoveGarbageBagFromPile(garbageBag);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GarbageBag"))
        {
            if (!cleaningScript.isCarryingGarbage)
            {
                cleaningScript.GetGarbageBagsObject(); // Here's the fix for the second error
            }
        }
    }
}
*/