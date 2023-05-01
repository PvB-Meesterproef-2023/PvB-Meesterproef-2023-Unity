using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cs1PieceVar : MonoBehaviour
{
    private bool pieceGrown = false;
    [SerializeField] GameObject parent;
    public List<GameObject> safeZoneList;

    public int despawnDelay = 5;

    bool onStartPos = true;
    bool holdingItem = true;
    Vector3 startingPos;

    string currentParent = null;

    private void Start()
    {
        startingPos = gameObject.transform.localPosition;
        Debug.Log(startingPos);
    }

    // Update is called once per frame
    void Update()
    {
        currentParent = this.transform.parent.name;
        Debug.Log(currentParent);
        if (currentParent != parent.name && this.transform.parent.parent.name != "RightHand" && this.transform.parent.parent.name != "LeftHand" && !onStartPos)
        {
            Debug.Log("WAITING");
            StartCoroutine(WaitForFunction());
        }
    }

    public void OnTriggerExit(Collider col)
    {
        for (int i = 0; i < safeZoneList.Count; i++)
        {
            if (col.gameObject == safeZoneList[i])
            {
                onStartPos = false;
                Debug.Log("OFF ZONE");
            }
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        for(int i = 0; i < safeZoneList.Count; i++)
        {
            if (col.gameObject == safeZoneList[i])
            {
                onStartPos = true;
                Debug.Log("ON ZONE");
            }
        }
    }

    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(despawnDelay);
        Debug.Log("DONE WAITING");
        resetPiece();

    }

    void resetPiece()
    {
        if (currentParent != parent.name && !onStartPos)
        {
            onStartPos = true;
            Debug.Log(startingPos);
            gameObject.transform.parent = parent.transform;
            gameObject.transform.localPosition = startingPos;
            Debug.Log("RESET");
        }
    }
}
