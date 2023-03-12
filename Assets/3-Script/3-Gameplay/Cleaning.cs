using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cleaning : MonoBehaviour
{
    public float cleanTime = 5f;
    public float maxCleanDistance = 2f;
    public GameObject garbageBagsPrefab;
    public Transform garbageBagsParent;
    private float timeLeft = 0f;
    private bool isCleaning = false;
    private bool isCarryingGarbage = false;
    public Image ringBar;
    public Image BgringBar;
    public TextMeshProUGUI pressE;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Show the ring bar only when the player is within the maximum clean distance
        if (distance <= maxCleanDistance)
        {
            pressE.gameObject.SetActive(true);
            ringBar.gameObject.SetActive(true);
            BgringBar.gameObject.SetActive(true);

            if (Input.GetKey(KeyCode.E) && !isCleaning)
            {
                isCleaning = true;
                timeLeft = cleanTime;
                GetComponent<Rigidbody>().isKinematic = true;
            }

            if (isCleaning && !Input.GetKey(KeyCode.E))
            {
                isCleaning = false;
                timeLeft = 0f;
                GetComponent<Rigidbody>().isKinematic = false;
                ringBar.fillAmount = 0f;
                return;
            }

            if (isCleaning)
            {
                timeLeft -= Time.deltaTime;
                ringBar.fillAmount = timeLeft / cleanTime;
                if (timeLeft <= 0f)
                {
                    GameObject garbageBagsObj = Instantiate(garbageBagsPrefab, garbageBagsParent);
                    garbageBagsObj.transform.localPosition = Vector3.zero;
                    isCarryingGarbage = true;
                    
                    Destroy(gameObject);
                    
                    ringBar.gameObject.SetActive(false);
                    BgringBar.gameObject.SetActive(false);
                    pressE.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            ringBar.gameObject.SetActive(false);
            BgringBar.gameObject.SetActive(false);
            pressE.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F) && isCarryingGarbage)
        {
            float distanceToTargetZone = Vector3.Distance(transform.position, garbageBagsParent.position);
            if (distanceToTargetZone <= maxCleanDistance)
            {
                GameObject garbageBagsObj = garbageBagsParent.GetChild(0).gameObject;
                Destroy(garbageBagsObj);
                isCarryingGarbage = false;
            }
        }

    }

}

//??????????????????????? ?????????????????????????????????????????????????