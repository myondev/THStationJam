using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Button thisButton;
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI cardText;
    [SerializeField] private TextMeshProUGUI cardDescription;
    public int cardNumber;

    public void SetUI(Card selectedCard)
    {
        cardImage.sprite = selectedCard.cardImage;
        cardText.text = selectedCard.cardName;
        cardDescription.text = selectedCard.description;
        thisButton.onClick.AddListener(() => CardManager.instance.UseCard(selectedCard));
    }
}
