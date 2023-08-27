using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicatorManager : MonoBehaviour
{
    [SerializeField] private GameObject DmgIndicatorPrefab;
    
    public void IndicateDamage(int damage, Vector2 pos, bool healing)
    {
        var dmgIndicator = Instantiate(DmgIndicatorPrefab, new Vector2(pos.x + 100, pos.y + 20), Quaternion.identity, GameObject.Find("Canvas").transform);
        dmgIndicator.GetComponent<DamageIndicator>().DisplayDamage(damage, healing);
    }
}
