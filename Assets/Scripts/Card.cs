using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Identification")] 
    public string cardName;
    public Sprite cardImage;

    [Header("Stat Changes")] 
    public int viewerModifier;
    public int subscriberModifier;
    public void ActivateCard()
    {
        CardEffects();
    }

    protected virtual void CardEffects()
    {
        //this is where the card stuff happens
    }
    
}
