using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardSpawner : MonoBehaviour
{
    public static CardSpawner instance;
    
    public GameObject cardPrefab;
    public Transform cardCenterPos;
    public Transform cardUpPos;
    public Transform cardDownPos;

    [SerializeField] public List<Card> cards;
    private List<Card> spawnedCards = new List<Card>();
    public int spawnedCardsCount;
    private Card lastCardSpawned;
    
    public LightIndicator violenceLight;
    public LightIndicator scienceLight;
    public LightIndicator planetLight;
    public LightIndicator pointerLight;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetSpawnedCards()
    {
        spawnedCards.Clear();
    }

    public void SpawnCard()
    {
        Destroy(GameObject.FindGameObjectWithTag("Card"));
        
        if (GameManager.GameOver)
        {
            spawnedCardsCount = 0;
            return;
        }
        
        if (cards.Count == spawnedCards.Count)
        {
            ResetSpawnedCards();
        }
        
        var cardToBeSpawned = GenerateRandomCard();
        
        var newCard = Instantiate(cardPrefab, GameManager.instance.game.transform);
        
        SetCardVariables(newCard, cardToBeSpawned);
        
        spawnedCards.Add(cardToBeSpawned);
        lastCardSpawned = cardToBeSpawned;
        spawnedCardsCount++;
    }

    Card GenerateRandomCard()
    {
        var randomIndex = Random.Range(0, cards.Count);
        var randomCard = cards[randomIndex];
        
        while (spawnedCards.Contains(randomCard) || lastCardSpawned == randomCard)
        {
            randomIndex = Random.Range(0, cards.Count);
            randomCard = cards[randomIndex];
        }

        return randomCard;
    }

    void SetCardVariables(GameObject newCard, Card cardToBeSpawned)
    {
        newCard.GetComponent<CardDisplay>().SetCardInfo(cardToBeSpawned);
        newCard.GetComponent<CardAnimation>().SetCardPositions(cardCenterPos, cardUpPos, cardDownPos);

        foreach (var choiceButton in newCard.GetComponentsInChildren<ChoiceButton>())
        {
            choiceButton.lightIndicators = new[]
            {
                violenceLight, scienceLight, planetLight, pointerLight
            };
        }

        foreach (var choice in newCard.GetComponentsInChildren<CardChoice>())
        {
            choice.choiceInfo = choice.IsChoiceUp() ? cardToBeSpawned.choiceUp : cardToBeSpawned.choiceDown;
        }
    }
}
