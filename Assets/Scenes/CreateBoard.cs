using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour
{


    public int boardSize = 2; 
    public GameObject squarePrefab; 
    public float squareSize = 1f; 


    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {

        int cell_counter = 1;


        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Vector3 position = new Vector3((i-boardSize / 2f) * squareSize, (j - boardSize / 2f) * squareSize, 0 );

                GameObject square = Instantiate(squarePrefab, position, Quaternion.identity, transform);

                square.GetComponent<SpriteRenderer>().material.color = Color.black;

                //assign value to each cell
                CellNum cellScript = square.GetComponent<CellNum>();
                cellScript.cell_num = cell_counter;
                cell_counter += 1;



            }
        }
    }


}
