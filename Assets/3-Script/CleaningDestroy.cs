using UnityEngine;

public class CleaningDestroy : MonoBehaviour
{
    public float clickTime = 5f;  // The duration of the long left click in seconds.
    private float clickTimer;     // The current time of the long left click.


    private void Update()
    {
        if (Input.GetMouseButton(0))  // Check if the left mouse button is pressed.
        {
            clickTimer += Time.deltaTime;
            if (clickTimer >= clickTime)  // Check if the long left click has reached its duration.
            {
                Destroy(gameObject);  // Destroy the enemy object.

            }
        }
        else  // Reset the click timer if the left mouse button is released.
        {
            clickTimer = 0f;
        }

    }

}