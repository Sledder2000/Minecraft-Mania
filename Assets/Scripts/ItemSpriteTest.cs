using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ItemSprites isprites = GameObject.Find("ItemSprites").GetComponent<ItemSprites>();

        Sprite sword = isprites.WoodSword;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
