using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] Text[] cardValues;

    internal void SetValues(Sprite sprite, string cardValue)
    {
        cardValues.ToList().ForEach( cardVal => cardVal.text = cardValue );
    }
}
