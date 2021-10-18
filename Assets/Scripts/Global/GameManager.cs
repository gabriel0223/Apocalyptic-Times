using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 originalPos;
    public Transform rightPos;
    public Transform downPos;
    public float animationDuration;
    public GameObject game;
    public GameObject menu;
    public ApocalypseSpawner apocalypseSpawner;

    public GameObject timelineImage;
    public GameObject skullImage;
    public GameObject apocalypseMessage;

    public static bool GameOver
    {
        set
        {
            
        }
        get => IndicatorManager.instance.DidThePlayerLose();
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }

        originalPos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartGameAnimation()
    {
        AudioManager.instance.Stop("TicTac");
        AudioManager.instance.PlaySoundAfterAnother("MaquinaLigar", "MaquinaLoop", 0);
        
        var pushOtherSection = transform.DOMove(rightPos.position, animationDuration);
        
        yield return new WaitForSeconds(0.5f);

        pushOtherSection.Pause();
        SwitchSection(game);
        transform.DOMove(originalPos, animationDuration)
            .OnComplete(() => CardSpawner.instance.SpawnCard());
        
    }
    
    IEnumerator BackToMenuAnimation()
    {
        AudioManager.instance.Play("TicTac");
        AudioManager.instance.Stop("MaquinaLoop");
        
        var pushOtherSection = transform.DOMove(rightPos.position, animationDuration);
        
        yield return new WaitForSeconds(0.5f);

        pushOtherSection.Pause();
        SwitchSection(menu);
        ResetGame();
        transform.DOMove(originalPos, animationDuration);
    }
    
    public void StartGame()
    {
        StartCoroutine(StartGameAnimation());
    }

    public void BackToMenu()
    {
        StartCoroutine(BackToMenuAnimation());
    }

    private void SwitchSection(GameObject section)
    {
        foreach (Transform child in transform) child.gameObject.SetActive(false);

        transform.position = downPos.position;
        section.SetActive(true);
    }

    private void ShowApocalypseMessage()
    {
        timelineImage.SetActive(false);
        skullImage.SetActive(false);
        apocalypseMessage.GetComponent<ApocalypseMessage>().score = CardSpawner.instance.spawnedCardsCount;
        apocalypseMessage.SetActive(true);
    }

    private void ResetTimeline()
    {
        timelineImage.SetActive(true);
        skullImage.SetActive(true);
        apocalypseMessage.SetActive(false);
    }

    private void ResetGame()
    {
        ResetTimeline();
        IndicatorManager.instance.ResetIndicators();
        CardSpawner.instance.ResetSpawnedCards();
    }

    public void EndGame(Apocalypse.ApocalypseType apocalypseType, int fillAmount)
    {
        GameOver = true;
        apocalypseSpawner.SpawnApocalypse(apocalypseType, fillAmount);
        ShowApocalypseMessage();
    }
}
