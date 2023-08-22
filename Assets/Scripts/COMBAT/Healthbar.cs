using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private Combatant AttachedTo;
    private GameObject HPIndicator;
    private TMPro.TMP_Text HPText;
    // Start is called before the first frame update
    void Awake()
    {
        AttachedTo = gameObject.transform.parent.GetComponent<Combatant>();
        HPIndicator = gameObject.transform.Find("HPIndicator").gameObject;
        HPText = gameObject.transform.Find("HPText").GetComponent<TMPro.TMP_Text>();
        UpdateHealthbar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthbar()
    {
        HPIndicator.transform.localScale = new Vector3((float)AttachedTo.HP / AttachedTo.MaxHP, 1, 0);
        HPText.text = AttachedTo.HP + " / " + AttachedTo.MaxHP;
    }
}
