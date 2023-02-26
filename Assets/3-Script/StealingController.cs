/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealingController : MonoBehaviour
{

    private float stealTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inStealRange)
        {
            // start stealing
            isStealing = true;
        }

        if (isStealing)
        {
            stealTime += Time.deltaTime;
            if (stealTime >= 5f)
            {
                // stop stealing
                isStealing = false;
                stealTime = 0f;
                // TODO: add code to actually steal the object
            }
        }
}
*/