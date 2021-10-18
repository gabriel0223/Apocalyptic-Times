using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ApocalypseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler
{
    public Transform postIt;
    private float originalY;
    public float hoverY;
    public float animationDuration;

    private void Awake()
    {
        originalY = postIt.localPosition.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.PlayRandomBetweenSounds(new []{"PostIt01", "PostIt02", "PostIt03", "PostIt04"});
        
        postIt.DOLocalMoveY(hoverY, animationDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        postIt.DOLocalMoveY(originalY, animationDuration);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Destroy(transform.parent.gameObject, 0.5f);
        GameManager.instance.BackToMenu();
    }
}
