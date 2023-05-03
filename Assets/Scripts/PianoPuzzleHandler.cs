using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzleHandler : MonoBehaviour
{
    // serialize field for animation
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject soundplayer;

    // Start is called before the first frame update


    void StartPiano()
    {
        // start animation
        animator.enabled = true;

        soundplayer.GetComponent<pianoSound>().PlayPiano();

    }

    // Update is called once per frame
    void Update()
    {
        // if button is pressed, start animation 
        if (Input.GetKeyDown(KeyCode.P) && !animator.enabled)
        {
            StartPiano();
        }
    }

}
