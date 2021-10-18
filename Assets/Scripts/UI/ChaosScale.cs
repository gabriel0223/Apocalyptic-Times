using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChaosScale : MonoBehaviour
{
    public float animationDuration;
    public float rigidness;
    public float minRot;
    public float maxRot;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotatePointer(float amount)
    {
        if (transform.localEulerAngles.z + amount >= maxRot || transform.localEulerAngles.z + amount <= minRot)
        {
            Debug.Log($"NO, because {transform.localEulerAngles.z} degrees is not allowed");
            return;
        }
        
        transform.DOLocalRotate(new Vector3(0, 0,  transform.localEulerAngles.z + amount), animationDuration);
    }

    public void ResetPointer()
    {
        transform.rotation = Quaternion.identity;
    }
}
