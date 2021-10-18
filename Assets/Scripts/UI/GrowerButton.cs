using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class GrowerButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Vector3 originalScale;
    public float hoverScaleMultiplier;
    public float hoverDuration;
    
    private void Awake()
    {
        originalScale = transform.localScale;
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
        AudioManager.instance.Play("MenuHover");
        transform.DOScale(originalScale * hoverScaleMultiplier, hoverDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(originalScale, hoverDuration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.Play("MenuClick");
    }
}
