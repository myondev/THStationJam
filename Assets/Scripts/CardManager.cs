using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private List<Card> availableCards;
    private List<GeneratedCard> currentCards = new();
    [SerializeField] private int maxCards; //the amount of cards you get during a stream
    [Header("UI")] 
    [SerializeField] private CardUI cardTemplate;
    [SerializeField] private Transform cardGrid;

    public bool canUseCards = true;
    
    public void GenerateCardUI(Card[] allCards)
    {
        availableCards = allCards.ToList();
        for (int i = 0; i < allCards.Length; i++)
        {
            if (i > currentCards.Count)
            {
                break; //probably shouldn't be possible but who knows!
            }
            int randomCard = Random.Range(0, availableCards.Count - 1);
            CardUI newCardUI = Instantiate(cardTemplate, cardGrid);
            currentCards.Add(new GeneratedCard {card = availableCards[randomCard], cardUI = newCardUI});
            newCardUI.SetUI(availableCards[randomCard]);
            newCardUI.gameObject.SetActive(true);
            availableCards.Remove(availableCards[randomCard]);
        }
    }
    public void UseCard(Card selectedCard)
    {
        if (!canUseCards) return;
        selectedCard.ActivateCard();
        foreach (GeneratedCard foundCardUI in currentCards)
        {
            if (foundCardUI.card == selectedCard)
            {
                Destroy(foundCardUI.cardUI.gameObject);
                currentCards.Remove(foundCardUI);
                if (currentCards.Count == 0) 
                    StartCoroutine(DayManager.instance.EndDay());
                return;
            }
        }
    }
}
