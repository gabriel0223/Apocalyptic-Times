using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class CardAnimation : MonoBehaviour
{
    public Ease easeType;
    public float overshoot;
    public float rigidness;
    public float animationDuration;

    [HideInInspector] public Transform cardCenterPos;
    [HideInInspector] public Transform cardUpPos;
    [HideInInspector] public Transform cardDownPos;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveCardCenter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCardCenter()
    {
        PlayCardMoveSound();
        transform.DOMove(cardCenterPos.position, animationDuration).SetEase(easeType, overshoot, rigidness);
    }

    public void MoveCardUp()
    {
        PlayCardMoveSound();
        transform.DOMove(cardUpPos.position, animationDuration).SetEase(easeType, overshoot, rigidness)
            .OnComplete(() => CardSpawner.instance.SpawnCard());
    }

    public void MoveCardDown()
    {
        PlayCardMoveSound();
        transform.DOMove(cardDownPos.position, animationDuration).SetEase(easeType, overshoot, rigidness)
            .OnComplete(() => CardSpawner.instance.SpawnCard());
    }

    public void SetCardPositions(Transform centerPos, Transform upPos, Transform downPos)
    {
        cardCenterPos = centerPos;
        cardUpPos = upPos;
        cardDownPos = downPos;
    }

    private void PlayCardMoveSound()
    {
        AudioManager.instance.PlayOneShotRandomBetweenSounds(new []{"CardMove01", "CardMove02", "CardMove03", "CardMove04", "CardMove05"});
    }
}
