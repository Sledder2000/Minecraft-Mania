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

    // Update is called once per frame
    void Update()
    {
       
        if (moveCounter < moves)
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                foreach (Tile tile in Tiles)
                {
                    if (tile.transform.position.x == transform.position.x && tile.transform.position.y == transform.position.y - 0.5)
                    {
                        if (!tile.IsFlipped)
                        {
                            transform.position += new Vector3(0, -2, 0);
                        }
                    }
                }
            
                transform.position += new Vector3(0, 2, 0);
            moveCounter++;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                foreach (Tile tile in Tiles)
                {
                    if (tile.transform.position.x == transform.position.x && tile.transform.position.y == transform.position.y - 0.5)
                    {
                        if (!tile.IsFlipped)
                        {
                            transform.position += new Vector3(0, 2, 0);
                        }
                    }
                }
                transform.position += new Vector3(0, -2, 0);
            moveCounter++;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                foreach (Tile tile in Tiles)
                {
                    if (tile.transform.position.x == transform.position.x && tile.transform.position.y == transform.position.y - 0.5)
                    {
                        if (!tile.IsFlipped)
                        {
                            transform.position += new Vector3(2, 0, 0);
                        }
                    }
                }
                transform.position += new Vector3(-2, 0, 0);
            moveCounter++;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                foreach (Tile tile in Tiles)
                {
                    if (tile.transform.position.x == transform.position.x && tile.transform.position.y == transform.position.y - 0.5)
                    {
                        if (!tile.IsFlipped)
                        {
                            transform.position += new Vector3(-2, 0, 0);
                        }
                    }
                }
                transform.position += new Vector3(2, 0, 0);
            moveCounter++;
            }
        }
    }
}
