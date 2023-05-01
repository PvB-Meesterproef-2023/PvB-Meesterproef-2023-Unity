using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwButton : MonoBehaviour
{
    [SerializeField] GameObject waterfallHitbox;
    Vector3 changeHitboxPos = new Vector3(0f, 1.0f, 0);

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "stone")
        {
            Debug.Log("HIT");
        }
    }
}
