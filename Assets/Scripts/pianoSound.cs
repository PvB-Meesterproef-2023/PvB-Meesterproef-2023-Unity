using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoSound : MonoBehaviour
{
    // serialized fields for game objects keys
    [SerializeField] private GameObject key1;
    [SerializeField] private GameObject key2;
    [SerializeField] private GameObject key3;
    [SerializeField] private GameObject key4;
    [SerializeField] private GameObject key5;
    [SerializeField] private GameObject key6;

    [SerializeField] private Animator animator;



    // Start is called before the first frame update
    public void PlayPiano()
    {
        InvokeRepeating("PlaySound", 1.0f, 1.0f);

    }



    private int i = 0;
    private void PlaySound()
    {
        Debug.Log(i);

        switch (i)
        {
            case 0:
                break;
            case 1:
                key1.GetComponent<AudioSource>().Play();
                PlayKey(key1);
                break;
            case 2:
                key2.GetComponent<AudioSource>().Play();
                PlayKey(key2);
                break;
            case 3:
                key3.GetComponent<AudioSource>().Play();
                PlayKey(key3);

                break;
            case 4:
                key4.GetComponent<AudioSource>().Play();
                PlayKey(key4);
                break;
            case 5:
                key5.GetComponent<AudioSource>().Play();
                PlayKey(key5);
                break;
            case 6:
                key6.GetComponent<AudioSource>().Play();
                PlayKey(key6);
                break;

        }

        i++;
        if (i >= 8)
        {
            CancelInvoke();
            animator.enabled = false;
            animator.Rebind();
            animator.Update(0f);
            i = 0;
        }
    }

    private void PlayKey(GameObject key)
    {
        StartCoroutine(key.GetComponent<CheckForInteractionPianoKey>().LerpDown());
        //StartCoroutine(key.GetComponent<CheckForInteractionPianoKey>().LerpUp());

    }
}
