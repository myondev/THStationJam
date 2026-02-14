using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI cardText;

    public void SetUI(Card selectedCard)
    {
        cardImage.sprite = selectedCard.cardImage;
        cardText.text = selectedCard.cardName;
    }
}
