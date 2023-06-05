using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TraumaEffect : MonoBehaviour
{
    private float _traumaLevel = 0.0f;
    public AudioSource heartbeatAudio;
    public VolumeProfile vignetteProfile;
    private Vignette _vignette;
    
    // Start is called before the first frame update
    void Start()
    {
        _vignette = (Vignette) vignetteProfile.components[0];
        _vignette.intensity.value = 0f;
        heartbeatAudio.volume = (float) Math.Pow(_traumaLevel, 2);
    }

    public void SetTraumaLevel(float t)
    {
        Assert.IsTrue(t >= 0 && t <= 1, "trauma level must be between 0 and 1");
        _traumaLevel = t;
        heartbeatAudio.volume = (float) Math.Pow(_traumaLevel, 2);
        _vignette.intensity.value = 0.5f * _traumaLevel;
    }

    public float GetTraumaLevel()
    {
        return _traumaLevel;
    }
}
