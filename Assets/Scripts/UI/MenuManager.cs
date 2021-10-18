using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] menuSections;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeMenuSection(GameObject menuSection)
    {
        if (menuSection.activeSelf) return;
        
        foreach (var section in menuSections)
        {
            section.SetActive(false);
        }
        
        menuSection.SetActive(true);
    }
}
