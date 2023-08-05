using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowsDropdown : MonoBehaviour
{
    public Player CurrentPlayer { get; private set; }

    public void ChangeArrows(int n)
    {
        CurrentPlayer.SetArrowsToUse(n + 1);
        Debug.Log(CurrentPlayer.ArrowsToUse);
    }
    
    public void SetCurrentPlayer(Player p)
    {
        CurrentPlayer = p;
    }
}
