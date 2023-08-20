using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrowsDropdown : MonoBehaviour
{
    public Player CurrentPlayer { get; private set; }

    private void Start()
    {
    }

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
