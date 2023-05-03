using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerdetector : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector3.Distance(transform.position, player.position));
        // check if the player is in a radius of 5
        if (Vector3.Distance(transform.position, player.position) < 15)
        {
            // if the player is in a radius of 5, then set the position of the camera to the position of the player
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
