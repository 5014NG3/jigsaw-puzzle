using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour
{


    public int boardSize = 2; 
    public GameObject squarePrefab; 
    public float squareSize = 1f;
    public static int puzzleProgress = 0;
    public static int totalPieces;


    private int cell_counter = 1;


    void Start()
    {
        GenerateBoard();
        totalPieces = boardSize * boardSize;
    }

    void GenerateBoard()
    {

        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Vector3 position = new Vector3((i - (boardSize - 1) / 2f) * squareSize, (j - (boardSize - 1) / 2f) * squareSize, 0);

                GameObject square = Instantiate(squarePrefab, position, Quaternion.identity, transform);
                square.name = "slot_" + cell_counter.ToString();

                square.GetComponent<SpriteRenderer>().material.color = Color.white;

                cell_counter += 1;



            }
        }
    }

    public static void DeletePieces()
    {
        string piecekey;
        for (int i = 0; i < totalPieces; i++)
        {
            piecekey = "piece_" + (i+1).ToString();
            GameObject piece = GameObject.Find(piecekey);
            Destroy(piece);
        }
    }

    public static void CountPiece()
    {
        puzzleProgress++;

        if (puzzleProgress == totalPieces)
        {
            //DeletePieces();
            //make the complete puzzle visible

            GameObject completePuzzle = GameObject.Find("complete_puzzle");

            SpriteRenderer renderer = completePuzzle.GetComponent<SpriteRenderer>();
            renderer.enabled = true;

            GameObject victory =  GameObject.Find("Victory");
            AudioSource victory_sound = victory.GetComponent<AudioSource>();
            victory_sound.Play();


        }


    }


}
