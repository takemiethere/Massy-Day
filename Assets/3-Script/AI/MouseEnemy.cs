using UnityEngine;
using System.Collections;

public class MouseEnemy : MonoBehaviour
{

    public Transform startZone; // the starting zone of the enemy
    public Transform targetZone; // the target zone where the enemy will move to
    public float moveSpeed = 5f; // the speed at which the enemy moves
    public float freezeTime = 2f; // the amount of time the enemy will freeze at the target zone
    public float startZoneRadius = 5f; // the radius around the start zone from which the target zone will be randomly selected
    public float runAwayDistance = 3f; // the distance at which the enemy will start running away from the player
    public Transform player; // the object representing the player

    private Vector3 startPosition; // the starting position of the enemy
    private Vector3 targetPosition; // the target position where the enemy will move to

    private bool isFrozen = false; // flag to indicate whether the enemy is currently frozen
    private float freezeTimer = 0f; // timer to keep track of how long the enemy has been frozen

    void Start()
    {
        startPosition = startZone.position; // set the starting position to the start zone
        targetPosition = targetZone.position; // set the initial target position to the target zone
        player = GameObject.FindGameObjectWithTag("Player").transform; // find the player object in the scene
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!isFrozen)
        {
            if (distanceToPlayer <= runAwayDistance)
            {
                // run away from the player
                transform.position = Vector3.MoveTowards(transform.position, transform.position - player.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                // move the enemy towards the target position
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                // check if the enemy has reached the target position
                if (transform.position == targetPosition)
                {
                    // start freezing the enemy
                    isFrozen = true;
                    freezeTimer = 0f;
                }
            }
        }
        else
        {
            // increment the freeze timer
            freezeTimer += Time.deltaTime;

            // check if the freeze timer has reached the freeze time
            if (freezeTimer >= freezeTime)
            {
                // unfreeze the enemy and set a new target position
                isFrozen = false;
                if (targetPosition == targetZone.position)
                {
                    targetPosition = startPosition;
                }
                else
                {
                    targetPosition = targetZone.position;
                }
            }
        }

        // Rotate towards the player
        transform.LookAt(player);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to visualize the start zone
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(startZone.position, startZoneRadius);

        // Draw a wire sphere to visualize the target zone
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetZone.position, startZoneRadius);
    }
}
