using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardPileView : MonoBehaviour
{
    [SerializeField] Animator cardAnimator;
    [SerializeField] Sprite[] suits;
    [SerializeField] GameObject currentCardGameObject;
 
    private List<Card> cards;
    private int pileIndex = 0;

    public void Initialize(List<Card> cards)
    {
        this.cards = cards;
        Shuffle(); 
        ShowNextCard();
    }

    private void ShowNextCard()
    {
        var cardView = currentCardGameObject.GetComponent<CardView>();
        var currentCard = cards[pileIndex];
        cardView.SetValues(suits[currentCard.suit - 1], currentCard.cardValue);
        cardAnimator.SetTrigger("ShowCard");
    }

    private void Shuffle()
    {
        System.Random random = new();
        cards = cards.OrderBy(_ => random.Next()).ToList();
    }
}
