using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIController : MonoBehaviour
{
    private GameObject AttackButton, ItemButton, CraftButton, RetreatButton, EndTurnButton, InventoryButton,
        CancelButton, ArrowsDropdown, ConfirmArrows, Inventory, BattleInfo;

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
     * 7 = enemy attack
     * 8 = retreating
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
        ArrowsDropdown = GameObject.Find("ArrowsDropdown");
        ConfirmArrows = GameObject.Find("ConfirmArrows");
        Inventory = GameObject.Find("InventoryView");
        BattleInfo = GameObject.Find("BattleInfo");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChangeState(int state)
    {
        //if (state < 0 || state > 8) { return; }
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
                BattleInfo.SetActive(true);
                BattleInfo.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = CC.GetActivePlayer().name + "'s turn";
                break;
            case 2:
                CancelButton.SetActive(true);
                BattleInfo.SetActive(true);
                BattleInfo.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Choose a target";
                CC.ShowHealthbars(true);
                break;
            case 3:
                CancelButton.SetActive(true);
                Inventory.SetActive(true);
                Inventory.GetComponent<InventoryViewManager>().GenerateEquipmentView(CC.GetActivePlayer().GetComponent<Inventory>());
                BattleInfo.SetActive(true);
                BattleInfo.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Choose a weapon";
                break;
            case 4:
                CancelButton.SetActive(true);
                break;
            case 5:
                Inventory.SetActive(true);
                Inventory.GetComponent<InventoryViewManager>().GenerateInventoryView(CC.GetActivePlayer().GetComponent<Inventory>());
                CancelButton.SetActive(true);
                break;
            case 6:
                CancelButton.SetActive(true);
                ArrowsDropdown.SetActive(true);
                ConfirmArrows.SetActive(true);
                BattleInfo.SetActive(true);
                ArrowsDropdown.GetComponent<ArrowsDropdown>().SetCurrentPlayer(CC.GetActivePlayer());
                ArrowsDropdown.GetComponent<TMPro.TMP_Dropdown>().value = 0;
                BattleInfo.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = 
                    "Select number of arrows (you have " + CC.GetActivePlayer().GetComponent<Inventory>().ItemCount(ItemList.Arrow) + ")";
                break;
            case 7:
                BattleInfo.SetActive(true);
                break;
            case 8:
                BattleInfo.SetActive(true);
                BattleInfo.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "Attempting to flee...";
                break;
        }
        if (state != 3 && state != 5) { Inventory.GetComponent<InventoryViewManager>().RemoveSpawnedItems(); }
        State = state;
    }
}
