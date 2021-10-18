using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LightIndicator : MonoBehaviour
{
    public enum Feedback
    {
        Positive, Negative, Neutral
    }
    
    private Image light;
    public Color neutralColor;
    public Color goodColor;
    public Color badColor;
    public float blinkDuration;
    public float smallLightSize;
    public float mediumLightSize;
    public float bigLightSize;
    
    [HideInInspector] public bool feedbacking;

    private void Awake()
    {
        light = transform.GetChild(0).GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlinkLight(Feedback feedback, float amount)
    {
        StartCoroutine(BlinkLightCoroutine(feedback, amount));
    }

    IEnumerator BlinkLightCoroutine(Feedback feedback, float amount)
    {
        feedbacking = true;
        
        AudioManager.instance.PlayRandomBetweenSounds(new []{"Led01", "Led02", "Led03", "Led04", "Led05", "Led06", "Led07"});
        
        var lightTransform = light.gameObject.transform;

        lightTransform.localScale = amount switch
        {
            5 => Vector2.one * smallLightSize,
            10 => Vector2.one * mediumLightSize,
            _ => Vector2.one * bigLightSize
        };

        light.color = feedback == Feedback.Positive ? goodColor : badColor;
        
        yield return new WaitForSeconds(1);

        FadeLight();
        
        void FadeLight()
        {
            light.DOFade(0, blinkDuration).
                OnComplete(() => lightTransform.localScale = Vector2.one * smallLightSize);
        }
        
        feedbacking = false;
    }

    public void LightOnOff(bool onOff)
    {
        light.color = new Color(neutralColor.r, neutralColor.g, neutralColor.b, light.color.a);

        light.DOFade(onOff ? 1 : 0, blinkDuration);
    }
}
