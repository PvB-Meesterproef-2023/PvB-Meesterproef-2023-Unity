using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class nextPuzzle : MonoBehaviour
{
    Vector3 startPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localPosition != startPos)
        {
            goToNextPuzzle();
        }
    }

    void goToNextPuzzle()
    {
        Debug.Log("WOW");
    }
}
