using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject P1, P2;
    Inventory inv1, inv2;
    Resource diamond, wood;
    Equipment ironsword;
    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.Find("Player 1");
        P2 = GameObject.Find("Player 2");
        inv1 = P1.GetComponent<Inventory>();
        inv2 = P2.GetComponent<Inventory>();

        diamond = ItemList.Diamond;
        wood = ItemList.Wood;
        ironsword = new Sword("Iron Sword", null, 69, 420);

        inv1.AddItems(diamond, 2);
        inv2.AddItems(diamond, 4);
        Debug.Log(inv1.HasItems(diamond, 3));
        Debug.Log(inv1.HasItems(diamond, 1));

        Debug.Log(inv2.HasItems(diamond, 3));
        Debug.Log(inv2.HasItems(diamond, 1));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
