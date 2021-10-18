using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    
    [Header("SUBJECT INFO")]
    public LocalizeStringEvent subjectName;
    public LocalizeStringEvent subjectAge;
    public LocalizeStringEvent subjectOccupation;
    public Image subjectPhotograph;
    
    [Header("CARD INFO")]
    public LocalizeStringEvent situationDescription;
    public LocalizeStringEvent choiceUp;
    public LocalizeStringEvent choiceDown;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        DisplayCardInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardInfo(Card injectedCard)
    {
        card = injectedCard;
    }

    private void DisplayCardInfo()
    {
        subjectName.StringReference = card.subjectName;
        subjectAge.StringReference = card.subjectAge;
        subjectOccupation.StringReference = card.subjectOccupation;
        subjectPhotograph.sprite = card.subjectPhotograph;
        
        situationDescription.StringReference = card.situationDescription;
        choiceUp.StringReference = card.choiceUp.decisionDescription;
        choiceDown.StringReference = card.choiceDown.decisionDescription;
    }
}
