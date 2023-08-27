using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurabilityBar : MonoBehaviour
{
    public Equipment AttachedTo;
    private GameObject DurabilityIndicator;
    // Start is called before the first frame update
    void Start()
    {
        DurabilityIndicator = gameObject.transform.Find("DurabilityIndicator").gameObject;
        UpdateDurability();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateDurability()
    {
        DurabilityIndicator.transform.localScale = new Vector3((float)AttachedTo.Durability / AttachedTo.MaxDurability, 1, 0);
        if (AttachedTo.Durability == 0) 
        {
            SpriteRenderer sprite = gameObject.transform.parent.GetComponent<SpriteRenderer>();
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
        }
    }
}
