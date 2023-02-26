using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ItemInteraction : MonoBehaviour
{
    Vector3 Initail_position;
    Quaternion Rot;
    int layerMask = 1 << 8;

    public FirstPersonMovement move, rotate;
    //public playerRotate rotate;
    public Transform InspectZone;


    public static GameObject currentObj , manager;
    private Rigidbody rb;

    bool isInspecting = false;

    private void Start()
    {
        manager =  GameObject.Find("PhysicsManage");
    }

    private void Update()
    {
        RaycastHit info;
        if (Physics.Raycast(transform.position, transform.forward, out info, 4f, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E) && !isInspecting)
            {
                StopAllCoroutines();
                currentObj = info.collider.gameObject;
                rb = currentObj.GetComponent<Rigidbody>();
                Initail_position = info.collider.transform.position;
                Rot = Quaternion.Euler(info.collider.transform.localEulerAngles);
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                move.enabled = false;
                rotate.enabled = false;
                StartCoroutine(MoveToTarget(currentObj, InspectZone.position, 0.8f));
                isInspecting = true;
                manager.GetComponent<ItemTransforms>().enabled = true;
            }
        }
        if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            StopAllCoroutines();
            manager.GetComponent<ItemTransforms>().enabled=false;
            currentObj.transform.rotation = Quaternion.Euler(Rot.eulerAngles);
            StartCoroutine(MoveToTarget(currentObj, Initail_position, Time.deltaTime * 100f));
            isInspecting = false;
            move.enabled = false;
            rotate.enabled = true;
            if (rb != null)
            {
                StartCoroutine(TogglePhysics(rb, true, 5f));
            }
        }
    }

    IEnumerator MoveToTarget(GameObject MoveObj, Vector3 Target, float Speed)
    {
        while( MoveObj.transform.position != Target)
        {
            MoveObj.transform.position = Vector3.MoveTowards(MoveObj.transform.position, Target,Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator TogglePhysics(Rigidbody rb, bool value, float TimeWiat)
    {
        yield return new WaitForSeconds(TimeWiat);
        rb.isKinematic = !value;
    }
}
