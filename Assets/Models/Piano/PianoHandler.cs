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
            //Debug.Log("Child: " + child.name);
            try
            {
                // if object doesnt have an audiosource object, add one
                if (!child.GetComponent<AudioSource>() && !child.name.Contains('P'))
                {
                    child.gameObject.AddComponent<AudioSource>();
                    child.gameObject.AddComponent<CheckForInteractionPianoKey>();


                    // add the mp3 file as an audio clip to the audio source of the piano key

                    child.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(("Piano/" + child.name));

                    // log the clip name
                    //Debug.Log("Clip name: " + child.GetComponent<AudioSource>().clip.name);

                    // set the mixer to the piano mixer
                    child.GetComponent<AudioSource>().outputAudioMixerGroup = mixer.FindMatchingGroups("Piano")[0];
                }

            }
            catch (System.Exception e)
            {
                Debug.Log("Error: " + e);
            }

        }


    }
}