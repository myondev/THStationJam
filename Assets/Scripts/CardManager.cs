using System;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [Header("Cards")]
    [SerializeField] private Card[] allCards;
    public List<Card> currentCards;
    [SerializeField] private int maxCards; //the amount of cards you get during a stream
    [Header("UI")] 
    [SerializeField] private CardUI cardTemplate;
    [SerializeField] private Transform cardGrid;
    

    private void Start()
    {
        GenerateCardUI();
    }

    private void GenerateCardUI()
    {
        foreach (Card foundCard in currentCards)
        {
            CardUI newCardUI = Instantiate(cardTemplate, cardGrid);
            newCardUI.SetUI(foundCard);
        }
    }
    public void UseCard(Card selectedCard)
    {
        selectedCard.ActivateCard();
        currentCards.Remove(selectedCard);
    }
}
