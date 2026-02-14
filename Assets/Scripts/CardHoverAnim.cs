using UnityEngine;
using UnityEngine.EventSystems;

public class CardHoverAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float speedToMove;
    public Vector2 offset;
    [SerializeField] private RectTransform rectTransform;
    private Vector2 targetPosition;
    private bool checkHovering;

    private void Update()
    {
        if (checkHovering)
        {
            if (rectTransform.anchoredPosition != targetPosition)
            {
                rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, speedToMove * Time.deltaTime);
            }
            else
            {
                checkHovering = false;
                rectTransform.anchoredPosition = Vector2.zero;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetPosition = Vector2.zero + offset;
        checkHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetPosition = Vector2.zero;
        checkHovering = true;
    }
}
