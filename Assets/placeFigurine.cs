using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeFigurine : MonoBehaviour
{
    [SerializeField] GameObject figurineObject;
    [SerializeField] GameObject staticObject;

    private void Start()
    {
        staticObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(figurineObject == col.gameObject && col.GetComponent<pieceVar>().hasGrown)
        {
            col.gameObject.SetActive(false);
            staticObject.SetActive(true);
        }
    }
}
