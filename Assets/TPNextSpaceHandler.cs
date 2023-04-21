using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPNextSpaceHandler : MonoBehaviour
{
    [SerializeField] private GameObject nextSpaceDoorEnter;
    [SerializeField] private GameObject TheRoom;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TheRoom.transform.Rotate(0, 0, -90);
            collision.gameObject.transform.position = nextSpaceDoorEnter.transform.position;
            // rotate the room 90 degrees

        }
    }
}
