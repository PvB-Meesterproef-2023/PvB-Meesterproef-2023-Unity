using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwButton : MonoBehaviour
{
    [SerializeField] GameObject waterfallWater;
    [SerializeField] GameObject throwItem;

    private void Start()
    {
        waterfallWater.SetActive(false);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == throwItem.name)
        {
            waterfallWater.SetActive(true);
        }
    }
}
