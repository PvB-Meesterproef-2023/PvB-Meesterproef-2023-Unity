using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Camera playercam;

    // Start is called before the first frame update
    private void Start()
    {
        // play animation
        Player.canMove = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // set location of camera to this
        if (playercam != null)
        {
            playercam.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }

        // if animation is finished, restart


    }
}
