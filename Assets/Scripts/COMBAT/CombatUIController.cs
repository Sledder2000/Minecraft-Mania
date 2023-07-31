using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIController : MonoBehaviour
{
    private GameObject AttackButton;
    private GameObject ItemButton;
    private GameObject CraftButton;
    private GameObject RetreatButton;
    private GameObject EndTurnButton;
    private GameObject InventoryButton;
    private GameObject CancelButton;
    private GameObject ArrowsDropdown;

    private GameObject Buttons;

    public int State { get; private set; }
    private CombatController CC;

    /**
     * 0 = no combat ui
     * 1 = player's action
     * 2 = selecting target
     * 3 = view weapons
     * 4 = view items
     * 5 = view inventory
     * 6 = arrow selection
     **/

    // Start is called before the first frame update
    void Start()
    {
        Buttons = GameObject.Find("CombatUIElements");
        CC = GameObject.Find("CombatController").GetComponent<CombatController>();

        AttackButton = GameObject.Find("AttackButton");
        ItemButton = GameObject.Find("ItemButton");
        CraftButton = GameObject.Find("CraftButton");
        RetreatButton = GameObject.Find("RetreatButton");
        EndTurnButton = GameObject.Find("EndTurnButton");
        InventoryButton = GameObject.Find("InventoryButton");
        CancelButton = GameObject.Find("CancelButton");
        Debug.Log(CancelButton.activeInHierarchy);
        ArrowsDropdown = GameObject.Find("ArrowsDropdown");

        ChangeState(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(int state)
    {
        if (state < 0 || state > 6) { return; }
        for (int i = 0; i < Buttons.transform.childCount; i++)
        {
            Buttons.transform.GetChild(i).gameObject.SetActive(false);
        }
        switch (state)
        {
            case 0:
                break;
            case 1:
                AttackButton.SetActive(true);
                ItemButton.SetActive(true);
                CraftButton.SetActive(true);
                RetreatButton.SetActive(true);
                EndTurnButton.SetActive(true);
                InventoryButton.SetActive(true);
                break;
            case 2:
                CancelButton.SetActive(true);
                break;
            case 3:
                CancelButton.SetActive(true);
                break;
            case 4:
                CancelButton.SetActive(true);
                break;
            case 5:
                CancelButton.SetActive(true);
                break;
            case 6:
                CancelButton.SetActive(true);
                ArrowsDropdown.SetActive(true);
                break;
        }
        State = state;
    }
}
