using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenrator : MonoBehaviour
{
    public GameObject TileForGeneration;
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 100; i++) { 
            Instantiate(TileForGeneration, new Vector3(1 + i, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
