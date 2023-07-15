using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context : MonoBehaviour
{
    [SerializeField] CardPileView cardPileView;
    [SerializeField] LevelLoaderView levelLoaderView;
    
    void Start()
    {
        //Hacer un context para la otra scena
        var game = new GamePresenter(cardPileView, levelLoaderView);
    }
}
