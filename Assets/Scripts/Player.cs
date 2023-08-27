using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    int moves = 5;
    int moveCounter = 0;
    Tile[] Tiles;

    // Start is called before the first frame update
    void Start()
    {
        Tiles = (Tile[])FindObjectsOfType(typeof(Tile));
    }

    protected void Move(Vector3 Direction)
    {
        foreach (Tile tile in Tiles)
        {
            if (tile.transform.position.x == transform.position.x && tile.transform.position.y == transform.position.y - 0.5)
            {
                if (tile.IsFlipped)
                {
                    transform.position += Direction;
                    break; 
                } else if (!tile.IsFlipped) 
                {
                    tile.Flip();
                    moveCounter += 100; 
                }
            }
        }
        moveCounter++;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (moveCounter < moves)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move(new Vector3(0, 2, 0));
                Move(new Vector3(0, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(new Vector3(0, -2, 0));
                Move(new Vector3(0, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(new Vector3(-2, 0, 0));
                Move(new Vector3(0, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(new Vector3(2, 0, 0));
                Move(new Vector3(0, 0, 0));
            }
        }
    }
}
