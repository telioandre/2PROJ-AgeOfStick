using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    /*
     * Method to set the actual volume.
     */
    public void SetLevel(float volume)
    {
        mixer.SetFloat("volume", volume);
    }
}
