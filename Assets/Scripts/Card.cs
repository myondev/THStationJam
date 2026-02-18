using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "New Card")]
public class Card : ScriptableObject //i believe it should be a scriptable object
{
    [Header("Identification")] 
    public string cardName;
    public Sprite cardImage;
    public string description;
    
    [Header("Stat Changes")] 
    public int viewerModifier;
    public int subscriberModifier;
    public string dialogToShow;
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
        StatsManager.instance.dialogManager.LaunchDialog(dialogToShow);
        CardManager.instance.canUseCards = false;
    }
    
}
