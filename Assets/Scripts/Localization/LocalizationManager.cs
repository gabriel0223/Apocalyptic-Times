using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    private void Start()
    {
        
    }

    // Start is called before the first frame update
    // IEnumerator Start()
    // {
    //     // yield return LocalizationSettings.InitializationOperation;
    //     //
    //     // LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(
    //     //     CultureInfo.CurrentUICulture);
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    static void SwitchLanguage(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        Debug.Log("CHANGE LANGUAGE");
    }

    private void DebugLocalization()
    {
        Debug.Log(LocalizationSettings.SelectedLocale);
    }
}
