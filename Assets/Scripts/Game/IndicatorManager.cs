using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorManager : MonoBehaviour
{
    public static IndicatorManager instance;
    
    public Image[] indicatorBars;
    public ChaosScale chaosPointer;
    
    public float animationDuration;
    public Ease easeType;
    public float rigidness;
    public float chaosRotation;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool DidThePlayerLose()
    {
        var loserIndicators = indicatorBars.Where(i => i.fillAmount >= 1 || i.fillAmount <= 0).ToArray();
        if (loserIndicators.Length == 0) return false;

        GameManager.instance.EndGame(loserIndicators[0].GetComponent<IndicatorBar>().indicatorType, (int)loserIndicators[0].fillAmount);
        return true;
    }

    public void BarChange(int index, float amount)
    {
        indicatorBars[index].DOFillAmount(indicatorBars[index].fillAmount + (amount / 100) * 2, animationDuration)
            .SetEase(easeType, 0, rigidness);
    }

    public void ChaosChange(float amount)
    {
        chaosPointer.RotatePointer(amount);
    }

    public void ResetIndicators()
    {
        foreach (var indicator in indicatorBars)
        {
            indicator.fillAmount = 0.5f;
        }
        
        chaosPointer.ResetPointer();
    }
}
