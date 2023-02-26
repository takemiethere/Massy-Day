/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeze : MonoBehaviour
{
    public bool isFrozen = false;
    public PickUp pickupScript;
    public float timeToFreeze = 5.0f;
    private float timer = 0.0f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isFrozen)
        {
            rb.velocity = Vector3.zero;
            rb.MovePosition(transform.position);
            timer += Time.deltaTime;

            if (timer >= timeToFreeze)
            {
                isFrozen = false;
                pickupScript.isStealing = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup" && !pickupScript.isStolen)
        {
            isFrozen = true;
            timer = 0.0f;
        }
    }
}
*/