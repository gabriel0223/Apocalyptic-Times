using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite buttonPressed;
    private Sprite buttonUnpressed;
    public float pressDuration;
    public LightIndicator lightIndicator;

    private Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonUnpressed = buttonImage.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.Play("ManualHover");
        lightIndicator.LightOnOff(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        lightIndicator.LightOnOff(false);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.Play("MenuButtonPress");
        StartCoroutine(SwitchButtonImage());
    }

    IEnumerator SwitchButtonImage()
    {
        if (buttonImage.sprite == buttonPressed) yield break;
        
        buttonImage.sprite = buttonPressed;
        yield return new WaitForSeconds(pressDuration);
        buttonImage.sprite = buttonUnpressed;
    }
}
