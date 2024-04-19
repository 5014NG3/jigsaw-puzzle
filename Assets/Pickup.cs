using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 offset;
    private float hoverDistance = 0.33f;
    private string slotKey;
    private Vector3 initialPosition;
    private bool isLocked = false;



    public Vector2 boxSize = new Vector2(1f, 1f);
    public Vector2 boxOffset = new Vector2(0f, 0f);
    public int pieceNumber = -1;





    void Start()
    {
        initialPosition = transform.position;
        slotKey =  "slot_" + pieceNumber.ToString();
    }

    void OnMouseDown()
    {
        if (!isLocked && Input.GetMouseButtonDown(0)) {
            //offset between sprite position and mouse position
            //transform.position -> current position of sprite in world space
            //input.mousePosition -> position of mouse
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
            isDragging = true;
        }
    }

    void OnMouseUp()
    {

        if (isLocked)
        {
            return;
        }

        isDragging = false;
        //CHECK IF WHERE THEY LEFT THE PIECE IS THE RIGHT SLOT

        GameObject slot = GameObject.Find(slotKey);
        if (slot != null)
        {
            Vector3 slotPosition = slot.transform.position;

            if (Vector3.Distance(transform.position, slotPosition) <= hoverDistance)
            {
                //snap into place 
                transform.position = slotPosition;

                isLocked = true;

            }
            else
            {
                //return to initial position
                transform.position = initialPosition;

            }
        }
    }



    void Update()
    {
        if (!isLocked && isDragging) {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition + offset);
        }

    }


}
