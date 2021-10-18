using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ApocalypseAnimation : MonoBehaviour
{
    public float animationDuration;
    public Transform targetPos;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveDocumentCenter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void MoveDocumentCenter()
    {
        AudioManager.instance.PlayRandomBetweenSounds(new []{"CardMove01", "CardMove02", "CardMove03", "CardMove04", "CardMove05"});
        transform.DOMove(targetPos.position, animationDuration);
    }
}
