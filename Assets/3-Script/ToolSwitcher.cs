/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitcher : MonoBehaviour
{
    public GameObject destroyBugTool;
    public GameObject destroyMouseTool;
    public GameObject cleaningTool;
    public GameObject sprayCan;
    public GameObject handObject;
    public GameObject bloomObject;

    private KeyCode[] toolSwitchKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };

    private int currentToolIndex = 0;

    void Start()
    {
        // Set the cleaning tool to be active and the destroy bug and mouse tools to be inactive at the start of the game
        cleaningTool.SetActive(true);
        destroyBugTool.SetActive(false);
        destroyMouseTool.SetActive(false);
    }

    void Update()
    {
        // Check if a tool switch key is pressed and switch to the corresponding tool
        for (int i = 0; i < toolSwitchKeys.Length; i++)
        {
            if (Input.GetKeyDown(toolSwitchKeys[i]))
            {
                SwitchToTool(i);
            }
        }
    }

    public void SwitchToCleaningTool()
    {
        // Set the cleaning tool to be active and the destroy bug and mouse tools to be inactive
        destroyBugTool.SetActive(false);
        destroyMouseTool.SetActive(false);
        cleaningTool.SetActive(true);

        currentToolIndex = 0;
    }

    public void SwitchToDestroyBugTool()
    {
        // Set the destroy bug tool to be active and the cleaning and destroy mouse tools to be inactive

        cleaningTool.SetActive(false);
        destroyMouseTool.SetActive(false);
        destroyBugTool.SetActive(true);

        currentToolIndex = 1;
    }


    public void SwitchToDestroyMouseTool()
    {
        // Set the destroy mouse tool to be active and the cleaning and destroy bug tools to be inactive
        destroyBugTool.SetActive(false);
        cleaningTool.SetActive(false);
        destroyMouseTool.SetActive(true);

        currentToolIndex = 2;
    }

    private void SwitchToTool(int index)
    {
        switch (index)
        {
            case 0:
                SwitchToCleaningTool();
                break;
            case 1:
                SwitchToDestroyBugTool();
                break;
            case 2:
                SwitchToDestroyMouseTool();
                break;
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwitcher : MonoBehaviour
{
    public GameObject destroyBugTool;
    public GameObject destroyMouseTool;
    public GameObject cleaningTool;
    public GameObject sprayCan;
    public GameObject handObject;
    public GameObject bloomObject;

    private KeyCode[] toolSwitchKeys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };

    private int currentToolIndex = 0;

    void Start()
    {
        // Set the cleaning tool to be active and the destroy bug and mouse tools to be inactive at the start of the game
        cleaningTool.SetActive(true);
        destroyBugTool.SetActive(false);
        destroyMouseTool.SetActive(false);

        // Hide the spray can, hand object, and bloom object at the start of the game
        /*sprayCan.SetActive(false);
        handObject.SetActive(true);
        bloomObject.SetActive(false);*/
    }

    void Update()
    {
        // Check if a tool switch key is pressed and switch to the corresponding tool
        for (int i = 0; i < toolSwitchKeys.Length; i++)
        {
            if (Input.GetKeyDown(toolSwitchKeys[i]))
            {
                SwitchToTool(i);
            }
        }
    }

    public void SwitchToCleaningTool()
    {
        // Set the cleaning tool to be active and the destroy bug and mouse tools to be inactive
        destroyBugTool.SetActive(false);
        destroyMouseTool.SetActive(false);
        cleaningTool.SetActive(true);

        currentToolIndex = 0;
    }

    public void SwitchToDestroyBugTool()
    {
        // Set the destroy bug tool to be active and the cleaning and destroy mouse tools to be inactive

        cleaningTool.SetActive(false);
        destroyMouseTool.SetActive(false);
        destroyBugTool.SetActive(true);

        currentToolIndex = 1;
    }


    public void SwitchToDestroyMouseTool()
    {
        // Set the destroy mouse tool to be active and the cleaning and destroy bug tools to be inactive
        destroyBugTool.SetActive(false);
        cleaningTool.SetActive(false);
        destroyMouseTool.SetActive(true);

        currentToolIndex = 2;
    }

    private void SwitchToTool(int index)
    {
        switch (index)
        {
            case 0:
                SwitchToCleaningTool();
                break;
            case 1:
                SwitchToDestroyBugTool();
                break;
            case 2:
                SwitchToDestroyMouseTool();
                break;
        }
    }

    private void OnMouseDown()
    {
        if (currentToolIndex == 1)
        {
            // Only destroy the bug when the "destroy bug" tool is active
            DestroyBug();
        }
        else if (currentToolIndex == 2)
        {
            // Only destroy the mouse when the "destroy mouse" tool is active
            DestroyMouse();
        }
    }

    private void DestroyBug()
    {
        // Add your bug destroying code here
        // This is just an example that destroys the game object immediately
        Destroy(gameObject);
    }

    private void DestroyMouse()
    {
        // Add your mouse destroying code here
        // This is just an example that destroys the game object immediately
        Destroy(gameObject);
    }
}
