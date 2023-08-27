using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int Position;
    public string Biome;
    public int Difficulty;
    public bool IsFlipped;

    //Biome types
    public Sprite Ocean;
    public Sprite Forest;
    public Sprite SnowyForest;
    public Sprite Mountains;
    public Sprite Volcano;
    public Sprite Desert;
    public Sprite Jungle;
    public Sprite Plains;
    public Sprite Fog;

    //private Vector3 scaleChange = new Vector3((float)1.25, (float)1.25, 1);
    public void Start()
    {

       // transform.localScale = scaleChange;

       // IsFlipped = false;

        Biome = "Mountains";
        //Sets terrain to Biome type
        RenderSprite(Biome);  


    }

    public void Update()
    {
        if (!IsFlipped) 
        { 
            this.GetComponent<SpriteRenderer>().sprite = Fog;
        } else 
        {
            RenderSprite(Biome);
        }
    }

    public void SetDifficulty(int difficulty) {  Difficulty = difficulty; }
    
    public void Flip() { IsFlipped = true; }

    public void SetPosition(Vector2Int position) { Position = position;}

    public void SetBiome(string biome) {  Biome = biome; }

    public void RenderSprite(string Biome)
    {
        if (Biome.Equals("Plains"))
        {
            this.GetComponent<SpriteRenderer>().sprite = Plains;
        }
        else if (Biome.Equals("Ocean"))
        {
            this.GetComponent<SpriteRenderer>().sprite = Ocean;
        }
        else if (Biome.Equals("Forest"))
        {
            this.GetComponent<SpriteRenderer>().sprite = Forest;
        }
        else if (Biome.Equals("SnowyForest"))
        {
            this.GetComponent<SpriteRenderer>().sprite = SnowyForest;
        }
        else if (Biome.Equals("Mountains"))
        {
            this.GetComponent<SpriteRenderer>().sprite = Mountains;
        }
        else if (Biome.Equals("Volcano"))
        {
            this.GetComponent<SpriteRenderer>().sprite = Volcano;
        }
        else if (Biome.Equals("Desert"))
        {
            this.GetComponent<SpriteRenderer>().sprite = Desert;
        }
        else if (Biome.Equals("Jungle"))
        {
            this.GetComponent<SpriteRenderer>().sprite = Jungle;
        }
    }
}
