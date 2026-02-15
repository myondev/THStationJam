using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "New Card")]
public class Card : ScriptableObject //i believe it should be a scriptable object
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
        //if i can guess...
        // 1. Activate whatever dialogue
        // 2. apply it's effects, stat changes likely
        // for example:
        
        StatsManager.instance.UpdateViewers(viewerModifier);
        StatsManager.instance.UpdateSubscribers(subscriberModifier);
        //but how will we do a card order??
        //i'll have to find out whenever they respond lol
        
    }
    
}
