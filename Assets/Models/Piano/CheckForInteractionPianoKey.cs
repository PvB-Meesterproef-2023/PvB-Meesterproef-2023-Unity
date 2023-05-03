using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForInteractionPianoKey : MonoBehaviour
{
    private Vector3 originalPos;


    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.GetComponent<AudioSource>().Play();

    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<AudioSource>().Play();
        // lerp the object downwards so it looks like it is being pressed
        // if object has audiosource, execute if
        if (gameObject.GetComponent<AudioSource>())
        {
            StartCoroutine(LerpDown());

        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    // lerp the object upwards so it looks like it is being released
    //    if (gameObject.GetComponent<AudioSource>())
    //    {
    //        StartCoroutine(LerpUp());
    //    }
    //}

    public IEnumerator LerpDown()
    {
        // limit to go down only 0.1f
        float timePassed = 0;
        float lerpTime = 0.5f;
        Vector3 startPos = transform.localPosition;
        Vector3 endPos = new(originalPos.x, originalPos.y - 0.03f, originalPos.z);
        while (timePassed < lerpTime)
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, timePassed / lerpTime);
            timePassed += Time.deltaTime;
            yield return null;
            StartCoroutine(LerpUp());

        }
    }

    public IEnumerator LerpUp()
    {
        float timePassed = 0;
        float lerpTime = 0.5f;
        Vector3 startPos = transform.localPosition;
        Vector3 endPos = new(originalPos.x, originalPos.y, originalPos.z);
        while (timePassed < lerpTime)
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, timePassed / lerpTime);
            timePassed += Time.deltaTime;
            yield return null;

        }
    }
}
