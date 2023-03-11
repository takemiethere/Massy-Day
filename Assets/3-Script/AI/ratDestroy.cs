

/*using UnityEngine;

public class ratDestroy : MonoBehaviour
{
    public int requiredClicks = 3; // number of clicks required to destroy object
    public float maxDistance = 10f; // maximum distance between player and butterfly enemy for it to be destroyable
    public float knockbackForce = 10f; // force applied to butterfly when it is destroyed
    public GameObject destroyEffect; // particle effect to play when butterfly is destroyed

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) <= maxDistance) // check if butterfly is within max distance
        {
            requiredClicks--;
            // play destroy effect
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }
            if (requiredClicks <= 0)
            {
                // apply knockback force
                if (rb != null)
                {
                    Vector3 direction = (transform.position - Camera.main.transform.position).normalized;
                    rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
                }
                // destroy butterfly
                Destroy(gameObject);
            }
        }
    }
}*/

using UnityEngine;

public class ratDestroy : MonoBehaviour
{
    public float maxDistance = 10f; // maximum distance between player and rat for it to be destroyable
    public float knockbackForce = 10f; // force applied to rat when it is destroyed
    public GameObject destroyEffect; // particle effect to play when rat is destroyed
    public Material hitMaterial; // material to apply to rat when it is hit

    private Rigidbody rb;
    private Renderer rend;
    private Material defaultMaterial;
    private RatDestroyUI ratDestroyUI;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;

        ratDestroyUI = FindObjectOfType<RatDestroyUI>();
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) <= maxDistance) // check if rat is within max distance
        {
            // play destroy effect
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
            }

            // apply knockback force
            if (rb != null)
            {
                Vector3 direction = (transform.position - Camera.main.transform.position).normalized;
                rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
            }

            // change material to hit material and destroy rat after delay
            if (hitMaterial != null)
            {
                rend.material = hitMaterial;
                Invoke("DestroyRat", 0.5f); // destroy rat after 0.5 seconds
            }
            else
            {
                DestroyRat();
            }
        }
    }

    private void DestroyRat()
    {
        Destroy(gameObject);
        ratDestroyUI.RatDestroyed();
    }

    private void OnDestroy()
    {
        rend.material = defaultMaterial;
    }
}
