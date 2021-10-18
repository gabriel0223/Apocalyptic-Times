using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosPointer : MonoBehaviour
{
    public float idleRotationSpeed;
    public float rotationRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion from = Quaternion.Euler(Vector3.forward * rotationRange);
        Quaternion to = Quaternion.Euler(Vector3.forward * -rotationRange);
        
        float lerp =  0.5f * (1.0f + Mathf.Sin( Mathf.PI * idleRotationSpeed * Time.time));
        transform.localRotation = Quaternion.Lerp(from, to, lerp);
    }
}
