using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageSelection : MonoBehaviour
{
    [SerializeField] private List<string> availableLanguages = new List<string>();
    private TextMeshProUGUI languageText;
    private Locale[] availableLocales;

    private IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        languageText = GetComponentInChildren<TextMeshProUGUI>();
        
        availableLocales = LocalizationSettings.AvailableLocales.Locales.ToArray();
        
        foreach (var lan in availableLocales)
        {
            availableLanguages.Add(lan.LocaleName);
        }
        
        languageText.SetText(availableLanguages[Array.IndexOf(availableLocales, LocalizationSettings.SelectedLocale)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SwitchLanguage(int change)
    {
        int index = Array.IndexOf(availableLocales, LocalizationSettings.SelectedLocale);

        if (index + change >= availableLocales.Length)
        {
            index = 0;
        }
        else if (index + change < 0)
        {
            index = availableLocales.Length - 1;
        }
        else
        {
            index += change;
        }
        
        LocalizationSettings.SelectedLocale = availableLocales[index];
        languageText.SetText(availableLanguages[index]);
    }
}
