using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//อย่าลืมใส่ Box Collider ที่ ส กิ น ไม่ใช่ที่ตัวกรุ๊ปเด้อ
public class PickUp : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    Debug.Log("something picked up");
                    Destroy(gameObject);
                }
            }
        }
    }
}