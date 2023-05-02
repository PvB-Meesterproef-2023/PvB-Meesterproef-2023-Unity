using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHitbox : MonoBehaviour
{
    [SerializeField] GameObject swanObject;
    [SerializeField] GameObject sparrowObject;
    [SerializeField] GameObject chickenObject;
    [SerializeField] GameObject duckObject;
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == swanObject.name ||
            col.gameObject.name == sparrowObject.name ||
            col.gameObject.name == chickenObject.name ||
            col.gameObject.name == duckObject.name && !col.gameObject.GetComponent<pieceVar>().hasGrown)
        {
            col.transform.localScale *= 2;
            col.gameObject.GetComponent<pieceVar>().hasGrown = true;
        }
        else
        {
            Debug.Log("HIT WATERFALL");
        }
    }
}
