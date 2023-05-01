using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cs1PieceVar : MonoBehaviour
{
    private bool pieceGrown = false;
    [SerializeField] GameObject originalParent;
    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;
    public List<GameObject> safeZoneList;

    public int despawnDelay = 5;

    bool onStartPos = true;
    bool holdingItem = true;
    Vector3 startingPos;

    string currentParent = null;

    private void Start()
    {
        startingPos = gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.parent == null && !onStartPos)
        {
            Debug.Log("WAITING");
            StartCoroutine(WaitForFunction());
        }
    }

    public void OnCollisionExit(Collision col)
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

    public void OnCollisionEnter(Collision col)
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
        if (this.transform.parent.parent.name != leftHand.name && this.transform.parent.parent.name != rightHand.name && !onStartPos)
        {
            onStartPos = true;
            Debug.Log(startingPos);
            gameObject.transform.parent = originalParent.transform;
            gameObject.transform.localPosition = startingPos;
            Debug.Log("RESET");
        }
    }
}
