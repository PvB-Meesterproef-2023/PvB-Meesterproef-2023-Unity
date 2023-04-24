using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPNextSpaceHandler : MonoBehaviour
{
    [SerializeField] private GameObject nextSpaceDoorEnter;
    [SerializeField] private GameObject TheRoom;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject PlayerObject;
    private Rigidbody PlayerRb;
    private void OnCollisionEnter(Collision collision)
    {
        // get rigidbody of player
        PlayerRb = PlayerObject.GetComponent<Rigidbody>();


        if (collision.gameObject.CompareTag("Player"))
        {

            // rotate the room 90 degrees
            TheRoom.transform.Rotate(0, 0, -90);
            // Player velocity to 0
            PlayerRb.velocity = Vector3.zero;
            Player.transform.position = nextSpaceDoorEnter.transform.position;
            PlayerObject.transform.position = nextSpaceDoorEnter.transform.position;


        }
    }
}
