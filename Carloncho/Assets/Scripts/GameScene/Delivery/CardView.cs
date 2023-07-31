using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text[] cardValues;
    [SerializeField] Sprite[] suits;
    [SerializeField] Animator cardAnimator;

    private void SetValues(Sprite sprite, string cardValue)
    {
        cardValues.ToList().ForEach( cardVal => cardVal.text = cardValue );
    }

    public void ShowFirstCard(Card currentCard)
    {
        Debug.Log(currentCard.suit);
        SetValues(suits[currentCard.suit - 1], currentCard.cardValue);
        cardAnimator.SetTrigger("ShowCard");
    }

    public void ShowSecondCard(Card currentCard)
    {
        SetValues(suits[currentCard.suit - 1], currentCard.cardValue);
        cardAnimator.SetTrigger("ShowSecondCard");
    }
}
