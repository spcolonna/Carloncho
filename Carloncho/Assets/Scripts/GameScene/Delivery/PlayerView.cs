using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] GameObject playerHalo;

    public void Select() => playerHalo.SetActive(true);
    public void Unselect() => playerHalo.SetActive(false);
}