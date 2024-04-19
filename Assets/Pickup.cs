using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;


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
        }
    }
}
