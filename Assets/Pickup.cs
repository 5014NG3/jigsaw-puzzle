using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;
    public Vector2 boxSize = new Vector2(1f, 1f);
    public Vector2 boxOffset = new Vector2(0f, 0f);

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) {
            //offset between sprite position and mouse position
            //transform.position -> current position of sprite in world space
            //input.mousePosition -> position of mouse
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }



    void Update()
    {
        if (isDragging) {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition + offset);

            GameObject slot = GameObject.Find("slot_1");
            if (slot != null)
            {
                Vector3 slotPosition = slot.transform.position;
                Debug.Log(slotPosition);
                Debug.Log(transform.position);

                float hoverDistance = 1.0f;
                if (Vector3.Distance(transform.position, slotPosition) <= hoverDistance)
                {
                    Debug.Log("Hovering over the slot 1");
                }
            }


        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);
    }
}
