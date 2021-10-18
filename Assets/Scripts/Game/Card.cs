using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class Choice
{
    public LocalizedString decisionDescription;
    public float violenceInfluence;
    public float scienceInfluence;
    public float planetInfluence;
    public float chaosInfluence;
}

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [Header("SUBJECT INFO")]
    public LocalizedString subjectName;
    public LocalizedString subjectAge;
    public LocalizedString subjectOccupation;
    public Sprite subjectPhotograph;
    
    [Header("CARD INFO")]
    public LocalizedString situationDescription;

    public Choice choiceUp;
    public Choice choiceDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
