using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Apocalypse", menuName = "Apocalypse")]
public class Apocalypse : ScriptableObject
{
    public enum ApocalypseType
    {
        Violence, Science, Nature
    }
    
    public string apocalypseID;
    public ApocalypseType apocalypseType;
    public int fillAmountRequired;
    
    public LocalizedString description;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
