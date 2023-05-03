using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceVar : MonoBehaviour
{
    public bool hasGrown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGrown)
        {
            Debug.Log("hasgrown");
        }
    }
}
