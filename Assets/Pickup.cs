using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;
    private string slot_key;
    private Vector3 initialPosition;


    public Vector2 boxSize = new Vector2(1f, 1f);
    public Vector2 boxOffset = new Vector2(0f, 0f);
    public int pieceNumber = -1;






    void Start()
    {
        initialPosition = transform.position;
        slot_key =  "slot_" + pieceNumber.ToString();
    }

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
        //CHECK IF WHERE THEY LEFT THE PIECE IS THE RIGHT SLOT

        GameObject slot = GameObject.Find(slot_key);
        if (slot != null)
        {
            Vector3 slotPosition = slot.transform.position;

            float hoverDistance = 0.25f;
            if (Vector3.Distance(transform.position, slotPosition) <= hoverDistance)
            {
                //snap into place 
                transform.position = slotPosition;

            }
            else
            {
                transform.position = initialPosition;
            }
        }
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
