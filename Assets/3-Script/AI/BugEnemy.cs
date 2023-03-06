using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugEnemy : MonoBehaviour
{
    public Transform target;
    public Transform player;
    public float speed = 10f;
    public float radius = 5f;
    public float threshold = 2f;
    public float height = 2f; // This is the height of the enemy off the floor
    public float followTime = 3f;
    private Rigidbody rb;
    private bool followingPlayer = false;
    private float followTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calculate the distance to the target and the player
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (followingPlayer)
        {
            // Follow the player for a certain amount of time
            followTimer -= Time.deltaTime;
            if (followTimer <= 0f)
            {
                followingPlayer = false;
            }
            rb.AddForce((player.position - transform.position).normalized * speed);
        }
        else if (distanceToPlayer < threshold)
        {
            // Follow the player if the player is close
            followingPlayer = true;
            followTimer = followTime;
            rb.AddForce((player.position - transform.position).normalized * speed);
        }
        else if (distanceToTarget > threshold)
        {
            // Move towards the target if the distance to the target is greater than the threshold
            rb.AddForce((target.position - transform.position).normalized * speed);
        }
        else
        {
            // Move in a circular path around the target if the distance to the target is less than the threshold
            float angle = Time.time * speed;
            float x = Mathf.Sin(angle) * radius;
            float z = Mathf.Cos(angle) * radius;
            Vector3 targetPos = target.position + new Vector3(x, 0, z);
            rb.AddForce((targetPos - transform.position).normalized * speed);
        }

        // Raise the enemy off the floor
        Vector3 position = transform.position;
        position.y = height;
        transform.position = position;

        // Rotate towards the target or the player
        if (followingPlayer)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.LookAt(target);
        }
    }
}
