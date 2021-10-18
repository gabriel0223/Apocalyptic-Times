using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ApocalypseSpawner : MonoBehaviour
{
    public GameObject apocalypsePrefab;
    public List<Apocalypse> apocalypses;
    public Transform documentTargetPos;
    
    private Transform canvas;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnApocalypse(Apocalypse.ApocalypseType apocalypseType, int fillAmount)
    {
        var newApocalypse = Instantiate(apocalypsePrefab, GameManager.instance.game.transform);
        var possibleApocalypses = apocalypses.FindAll(a => a.apocalypseType == apocalypseType &&
                                                           a.fillAmountRequired == fillAmount);
        
        var chosenApocalypse = possibleApocalypses[Random.Range(0, possibleApocalypses.Count)];
        
        newApocalypse.GetComponent<ApocalypseDisplay>().SetApocalypseInfo(chosenApocalypse);
        newApocalypse.GetComponent<ApocalypseAnimation>().targetPos = documentTargetPos;
    }
}
