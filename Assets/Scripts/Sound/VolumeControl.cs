using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    private TextMeshProUGUI volumeText;

    private void Awake()
    {
        volumeText = GetComponentInChildren<TextMeshProUGUI>();
        volumeText.SetText(100 + "%");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume(int operation)
    {
        var volChange = (float)operation;
        
        if (AudioListener.volume + volChange/10 > 1.1f || AudioListener.volume + volChange/10 < -0.1f) return;
        
        AudioListener.volume = volChange > 0 ? AudioListener.volume + 0.1f : AudioListener.volume + -0.1f;

        if (AudioListener.volume > 1f) AudioListener.volume = 1f;

        if (AudioListener.volume > 0.05f && AudioListener.volume < 1f)
        {
            volumeText.SetText((int)(Math.Ceiling(AudioListener.volume * 100)) + "%");
        }
        else if (AudioListener.volume < 0.05f)
        {
            volumeText.SetText(0 + "%");
        }
        else
        {
            volumeText.SetText(100 + "%"); 
        }
    }
}
