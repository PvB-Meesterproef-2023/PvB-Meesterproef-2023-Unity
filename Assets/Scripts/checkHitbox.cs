using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHitbox : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "figurine")
        {
            Debug.Log("GOOD OBJECT");
            col.transform.localScale *= 2;
        }
        else
        {
            Debug.Log("HIT");
        }
    }
}
