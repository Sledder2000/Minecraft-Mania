using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAction : MonoBehaviour
{
    public bool ActionTaken;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        ActionTaken = false;
        Player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool TakeAction(int action) // 0 = move, 1 = mine, 2 = rest
    {
        if (ActionTaken) { return false; }
        switch (action)
        {
            case 0:
                Move();
                return true;
            case 1:
                Mine();
                return true;
            case 2:
                Rest();
                return true;
            default:
                Debug.Log("invalid action for " + Player.name);
                return false;
        }
    }
    public void Move()
    {

    }

    public void Mine()
    {

    }

    public void Rest()
    {
        if (Player.GetComponent<Inventory>().HasPermItem(ItemList.Bed))
        {
            Player.GetComponent<Combatant>().Heal(Player.GetComponent<Combatant>().MaxHP);
        }
        else
        {
            Player.GetComponent<Combatant>().Heal(Player.GetComponent<Combatant>().MaxHP / 2);
        }
    }
}
