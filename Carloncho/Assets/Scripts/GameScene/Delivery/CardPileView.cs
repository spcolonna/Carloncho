using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardPileView : MonoBehaviour
{
    [SerializeField] Animator cardAnimator;

    private List<Card> cards;

    public void Initialize(List<Card> cards)
    {
        this.cards = cards;
        Shuffle(); 
        ShowNextCard();
    }

    private void ShowNextCard()
    {
        cardAnimator.SetTrigger("ShowCard");
    }

    private void Shuffle()
    {
        System.Random random = new();
        cards = cards.OrderBy(_ => random.Next()).ToList();
    }
}
