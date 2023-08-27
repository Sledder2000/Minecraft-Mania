using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int PlayerCount;
    public int TurnCounter { get; private set; }
    public int PlayerTurn { get; private set; }
    public GameObject ActivePlayer { get; private set; }
    private GameObject[] Players;
    

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerCount <= 0 || PlayerCount > 4)
        {
            Debug.Log("Invalid number of players!");
            return;
        }
        Players = new GameObject[PlayerCount];
        GameObject player1 = GameObject.Find("Player 1");
        Players[0] = player1;
        ActivePlayer = player1;
        if (PlayerCount > 1)
        {
            GameObject player2 = GameObject.Find("Player 2");
            Players[1] = player2;
        }
        if (PlayerCount > 2)
        {
            GameObject player3 = GameObject.Find("Player 3");
            Players[2] = player3;
        }
        if (PlayerCount > 3)
        {
            GameObject player4 = GameObject.Find("Player 4");
            Players[3] = player4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        TurnCounter = 1;
        PlayerTurn = 1;
    }

    public void NextPlayerTurn()
    {
        if (PlayerTurn == PlayerCount)
        {
            PlayerTurn = 0;
            TurnCounter++;
        }
        PlayerTurn++;
        ActivePlayer = Players[PlayerTurn - 1];
    }
}
