using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    private AudioSource _audioSource;
    public static float[] Samples = new float[512];

    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSpectrumSource();
    }

    void AudioSpectrumSource()
    {
        _audioSource.GetSpectrumData(Samples, 0, FFTWindow.Blackman);
    }
}
