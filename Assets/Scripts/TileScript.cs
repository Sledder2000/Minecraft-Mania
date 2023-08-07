using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileScript : TileBase
{
    public Tilemap tilemap = new Tilemap();
    ArrayList terrainType = new ArrayList();
    ArrayList terrainPos = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            terrainPos.Add(position);
            terrainType.Add(GetTerrain(position));
            Debug.Log(GetTerrain(position));
        }
        Debug.Log(terrainType);
        Debug.Log(terrainType.Count);
        for(int i = 0; i < terrainType.Count; i++) 
        {
            Debug.Log(terrainType[i]);
            Debug.Log(terrainPos[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetTerrain(Vector3Int pos)
    {
        return tilemap.GetSprite((Vector3Int)pos);
    }


}
