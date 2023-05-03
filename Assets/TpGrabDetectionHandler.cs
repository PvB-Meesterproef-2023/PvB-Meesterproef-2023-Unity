using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpGrabDetectionHandler : MonoBehaviour
{
    [SerializeField] Transform CameraOffset;
    private int i;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().isKinematic && i == 0)
        {
            CameraOffset.position = new(transform.position.x, transform.position.y + 5, transform.position.z);
            i++;
        }
    }
}
