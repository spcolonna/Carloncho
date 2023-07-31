using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardPileView : MonoBehaviour
{
    [SerializeField] GameObject firstCardGameObject;
    [SerializeField] GameObject secondCardGameObject;

    private List<Card> cards;
    private int pileIndex = 0;

    public void Initialize(List<Card> cards)
    {
        this.cards = cards;
        Shuffle(); 
        StartCoroutine(ShowNextCard());
    }

    private IEnumerator ShowNextCard()
    {
        var cardView = firstCardGameObject.GetComponent<CardView>();
        var currentCard = cards[pileIndex];
        cardView.ShowFirstCard(currentCard);
        yield return new WaitForSeconds(1.3f);
        ShowSecondCard();
    }

    private void ShowSecondCard()
    {
        var cardView = secondCardGameObject.GetComponent<CardView>();
        var currentCard = cards[pileIndex];
        cardView.ShowSecondCard(currentCard);
    }

    private void Shuffle()
    {
        System.Random random = new();
        cards = cards.OrderBy(_ => random.Next()).ToList();
    }
}
