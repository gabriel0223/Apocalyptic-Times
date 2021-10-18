using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ChoiceButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public CardChoice choicePostIt;
    private float originalY;
    public float hoverY;
    public float animationDuration;

    public LightIndicator[] lightIndicators;
    private float[] influences;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        influences = new[]
        {
            choicePostIt.choiceInfo.violenceInfluence,
            choicePostIt.choiceInfo.scienceInfluence,
            choicePostIt.choiceInfo.planetInfluence,
            choicePostIt.choiceInfo.chaosInfluence
        };

        originalY = choicePostIt.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.PlayRandomBetweenSounds(new []{"PostIt01", "PostIt02", "PostIt03", "PostIt04"});
        
        choicePostIt.transform.DOLocalMoveY(hoverY, animationDuration);

        for (var i = 0; i < influences.Length; i++)
        {
            if (influences[i] == 0 || lightIndicators[i].feedbacking) continue;

            lightIndicators[i].LightOnOff(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        choicePostIt.transform.DOLocalMoveY(originalY, animationDuration);
        
        for (var i = 0; i < influences.Length; i++)
        {
            if (influences[i] == 0 || lightIndicators[i].feedbacking) continue;
        
            lightIndicators[i].LightOnOff(false);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        for (var i = 0; i < influences.Length; i++)
        {
            if (influences[i] == 0) continue;

            lightIndicators[i]
                .BlinkLight(influences[i] > 0 ? LightIndicator.Feedback.Positive : LightIndicator.Feedback.Negative, Mathf.Abs(influences[i]));
        }
        
        choicePostIt.ProcessChoice();
    }
}
