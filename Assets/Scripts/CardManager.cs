using System;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    #region Statication

    public static CardManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    #endregion
    private class GeneratedCard
    {
        public Card card;
        public CardUI cardUI;
    }
    [Header("Cards")]
    [SerializeField] private Card[] allCards;
    public List<Card> currentCards;
    [SerializeField] private int maxCards; //the amount of cards you get during a stream
    [Header("UI")] 
    private List<GeneratedCard> allCardUIs = new();
    [SerializeField] private CardUI cardTemplate;
    [SerializeField] private Transform cardGrid;
    

    private void Start()
    {
        GenerateCardUI();
    }

    private void GenerateCardUI()
    {
        foreach (Card foundCard in currentCards) //no, that's not how it works but i'll fix that later
        {
            CardUI newCardUI = Instantiate(cardTemplate, cardGrid);
            allCardUIs.Add(new GeneratedCard {card = foundCard, cardUI = newCardUI});
            newCardUI.SetUI(foundCard);
            newCardUI.gameObject.SetActive(true);
        }
    }
    public void UseCard(Card selectedCard)
    {
        selectedCard.ActivateCard();
        currentCards.Remove(selectedCard);
        foreach (GeneratedCard foundCardUI in allCardUIs)
        {
            if (foundCardUI.card == selectedCard)
            {
                Destroy(foundCardUI.cardUI.gameObject);
                allCardUIs.Remove(foundCardUI);
                return;
            }
        }
    }
}
