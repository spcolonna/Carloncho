using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    [SerializeField] CardPileView cardPileView;
    
    void Start()
    {
        var game = new GamePresenter(cardPileView);
    }
}
