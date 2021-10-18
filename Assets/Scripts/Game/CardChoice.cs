using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChoice : MonoBehaviour
{
    private CardAnimation cardAnimation;
    public Choice choiceInfo;

    private void Awake()
    {
        cardAnimation = transform.parent.GetComponent<CardAnimation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessChoice()
    {
        if (IsChoiceUp()) //if choice is UP
        {
            cardAnimation.MoveCardUp();
        }
        else
        {
            cardAnimation.MoveCardDown();
        }

        foreach (var choiceButton in FindObjectsOfType<ChoiceButton>())
        {
            Destroy(choiceButton);
        }

        float[] influenceValues =
        {
            choiceInfo.violenceInfluence,
            choiceInfo.scienceInfluence,
            choiceInfo.planetInfluence
        };
        
        var indicatorBars = IndicatorManager.instance.indicatorBars;

        for (var i = 0; i < indicatorBars.Length; i++)
        {
            if (influenceValues[i] == 0) continue;

            IndicatorManager.instance.BarChange(i, influenceValues[i]);
        }
        
        IndicatorManager.instance.ChaosChange(choiceInfo.chaosInfluence);
    }

    public bool IsChoiceUp()
    {
        return GetComponent<RectTransform>().localPosition.y > 0;
    }
}
