using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour
{


    public int boardSize = 2; 
    public GameObject squarePrefab; 
    public float squareSize = 1f; 

    private int cell_counter = 1;


    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {

        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Vector3 position = new Vector3((i-boardSize / 2f) * squareSize, (j - boardSize / 2f) * squareSize, 0 );

                GameObject square = Instantiate(squarePrefab, position, Quaternion.identity, transform);
                square.name = "slot_" + cell_counter.ToString();

                square.GetComponent<SpriteRenderer>().material.color = Color.black;

                cell_counter += 1;



            }
        }
    }


}
