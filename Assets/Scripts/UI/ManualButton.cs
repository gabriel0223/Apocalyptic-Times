using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ManualButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private Vector3 originalPos;
    public Transform openManualPos;
    public float hoverScaleMultiplier;
    public float hoverDuration;
    public float openManualScaleMultiplier;
    public float openManualDuration;
    private bool manualOpen;
    private Image buttonImage;

    private void Awake()
    {
        originalScale = transform.localScale;
        originalPos = transform.localPosition;
        buttonImage = GetComponent<Image>();
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
        if (manualOpen) return;
        
        AudioManager.instance.Play("ManualHover");
        transform.DOScale(originalScale * hoverScaleMultiplier, hoverDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (manualOpen) return;
        
        transform.DOScale(originalScale, hoverDuration);
    }

    public void OpenManual()
    {
        if (manualOpen) return;
        
        AudioManager.instance.Play("ManualAbrindo");
        manualOpen = true;
        buttonImage.DOFade(0, openManualDuration);
        GetComponentInChildren<CanvasGroup>().DOFade(1, openManualDuration);
        transform.DOMove(openManualPos.position, openManualDuration);
        transform.DOScale(originalScale * openManualScaleMultiplier, openManualDuration);
    }

    public void CloseManual()
    {
        AudioManager.instance.Play("ManualAbrindo");
        buttonImage.DOFade(1, openManualDuration);
        GetComponentInChildren<CanvasGroup>().DOFade(0, openManualDuration);
        transform.DOLocalMove(originalPos, openManualDuration);
        transform.DOScale(originalScale, openManualDuration)
            .OnComplete(() => manualOpen = false);
    }
}
