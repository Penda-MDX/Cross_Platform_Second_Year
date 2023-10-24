using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class AudioInput : MonoBehaviour
{

    public float volumeThreshold = 0.1f; // adjust this value to set the minimum volume level for detection
    public float pitchThreshold = 0.1f; // adjust this value to set the minimum pitch level for detection

    public AudioSource audioSource;
    public static float volume;
    public static float pitch;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();
    }

    void Update()
    {
        float[] samples = new float[audioSource.clip.samples * audioSource.clip.channels];
        audioSource.clip.GetData(samples, 0);

        volume = 0f;
        pitch = 0f;

        // calculate the volume of the audio sample
        for (int i = 0; i < samples.Length; i++)
        {
            volume += Mathf.Abs(samples[i]);
        }
        volume /= samples.Length;

        // calculate the pitch of the audio sample
        float[] spectrum = new float[512];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        float maxVal = 0f;
        int maxIndex = 0;
        for (int i = 0; i < spectrum.Length; i++)
        {
            if (spectrum[i] > maxVal && spectrum[i] > pitchThreshold)
            {
                maxVal = spectrum[i];
                maxIndex = i;
            }
        }
        pitch = maxIndex * (AudioSettings.outputSampleRate / 2f) / spectrum.Length;

        // check if the volume and pitch exceed the thresholds
        
        if (volume > volumeThreshold) {
        Debug.Log("___________________");
            Debug.Log("Volume detected: " + volume);
        }
        if (pitch > pitchThreshold) {
            Debug.Log("Pitch detected: " + pitch);
             Debug.Log("___________________");
        }
        
        if ((volume > volumeThreshold) && (pitch > pitchThreshold))
        {
            //Debug.Log("Volume detected: " + volume + " " + "Pitch detected: " + pitch);
        }


    }
}