using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestroyChild : MonoBehaviour
{
    public GameObject target;
    public Material redMaterial;
    public Material defaultMaterial;
    public TextMeshProUGUI countText;

    private bool isInZone = false;
    private int destroyedCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Check if the target has at least one child before turning the zone red
            if (target.transform.childCount > 0)
            {
                isInZone = true;
                Debug.Log("Player entered zone");
                GetComponent<Renderer>().material = redMaterial;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInZone = false;
            Debug.Log("Player exited zone");
            GetComponent<Renderer>().material = defaultMaterial;
        }
    }

    private void Update()
    {
        if (isInZone && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Destroying child objects");
            foreach (Transform child in target.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject != target.gameObject)
                {
                    Destroy(child.gameObject);
                    destroyedCount++;
                }
            }
            countText.text = "Throw the trash  " + destroyedCount + "/10";
        }
    }
}
