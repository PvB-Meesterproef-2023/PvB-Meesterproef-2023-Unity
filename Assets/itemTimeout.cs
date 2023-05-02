using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class itemTimeout : MonoBehaviour
{
    [SerializeField] GameObject originalParent;
    [SerializeField] GameObject safeZone;

    public int despawnDelay = 5;

    bool onStartPos = false;
    Vector3 startingPos;

    string currentParent = null;

    private void Start()
    {
        startingPos = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.parent != originalParent && !onStartPos && !gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            Debug.Log("WAITING");
            StartCoroutine(WaitForFunction());
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject == safeZone)
        {
            onStartPos = false;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
            if (col.gameObject == safeZone)
            {
                onStartPos = true;
            }
    }

    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(despawnDelay);
        resetPiece();

    }

    void resetPiece()
    {
        if (!onStartPos)
        {
            onStartPos = true;
            Debug.Log(startingPos);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.transform.parent = originalParent.transform;
            gameObject.transform.localPosition = startingPos;
            Debug.Log("RESET");
        }
    }
}
