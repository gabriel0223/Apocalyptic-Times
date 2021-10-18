using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

public class ApocalypseDisplay : MonoBehaviour
{
    public TextMeshProUGUI apocalypseID;
    public LocalizeStringEvent apocalypseDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetApocalypseInfo(Apocalypse injectedApocalypse)
    {
        apocalypseID.SetText("APOCALYPSE " + injectedApocalypse.apocalypseID);
        apocalypseDescription.StringReference = injectedApocalypse.description;
    }
}
