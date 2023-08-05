using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableWeapon : MonoBehaviour
{
    private CombatUIController CUI;
    public Weapon Wpn;
    public Player Owner;
    // Start is called before the first frame update
    void Start()
    {
        CUI = GameObject.Find("CombatUIController").GetComponent<CombatUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Owner.ChangeEquippedWeapon(Wpn)) 
        {
            if (Owner.EquippedWeapon is Bow) {
                Owner.SetArrowsToUse(1);
                CUI.ChangeState(6); 
            }
            else { CUI.ChangeState(2); }
        }
    }
}
