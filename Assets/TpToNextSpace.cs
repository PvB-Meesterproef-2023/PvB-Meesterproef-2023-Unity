using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.UI;

public class TpToNextSpace : MonoBehaviour
{
    [SerializeField] private Transform theRoom;
    [SerializeField] private Quaternion RoomRotation;
    [SerializeField] private Transform NextSpacePosition;
    [SerializeField] private Transform CameraOffset;

    [SerializeField] private Image CanvasFadeOut;

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
            StartCoroutine(FadeImage(true));
            theRoom.rotation = RoomRotation;
            CameraOffset.position = NextSpacePosition.position;
            // fade out the canvas and then fade it back in after 2 seconds


            i++;
        }

    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                CanvasFadeOut.color = new Color(100, 10, 10, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                CanvasFadeOut.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
