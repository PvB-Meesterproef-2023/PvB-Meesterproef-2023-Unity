using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PianoHandler : MonoBehaviour
{
    // serialize field for player camera
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private GameObject pianoModel;
    [SerializeField] private AudioMixer mixer;

    private void Start()
    {
        // log all mixer groups
        foreach (AudioMixerGroup group in mixer.FindMatchingGroups("Piano"))
        {
            //Debug.Log("Mixer group: " + group.name);
        }

        foreach (Transform child in pianoModel.transform)
        {
            if (child.name.Contains("note", System.StringComparison.OrdinalIgnoreCase))
            {
                //Debug.Log("Child: " + child.name);
                try
                {
                    // if object doesnt have an audiosource object, add one
                    if (!child.GetComponent<AudioSource>())
                    {
                        child.gameObject.AddComponent<AudioSource>();
                    }
                    // add the mp3 file as an audio clip to the audio source of the piano key

                    child.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(("Piano/" + child.name));

                    // log the clip name
                    //Debug.Log("Clip name: " + child.GetComponent<AudioSource>().clip.name);

                    // set the mixer to the piano mixer
                    child.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("Piano")[0];
                }
                catch (System.Exception e)
                {
                    Debug.Log("Error: " + e);
                }
            }

        }


    }

    private void Update()
    {

        // if press left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // if player looks at note log the note name
            if (PlayerCamera.GetComponent<Camera>().GetComponent<Camera>().enabled == true)
            {
                Ray ray = PlayerCamera.GetComponent<Camera>().GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                if (Physics.Raycast(ray, out RaycastHit hit, 4))
                {
                    // log hit object
                    GameObject hitObject = hit.collider.gameObject;
                    if (hitObject.transform.IsChildOf(pianoModel.transform))
                    {
                        // The hit object is a child of the piano model, so it's a piano key
                        if (hitObject.name.Contains("note", System.StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Log("Hit piano key: " + hitObject.name);
                            // get audiosource from key and play it
                            Debug.Log(hitObject.GetComponent<AudioSource>().clip.name);
                            hitObject.GetComponent<AudioSource>().Play();
                        }
                    }
                }
            }
        }
    }
}
