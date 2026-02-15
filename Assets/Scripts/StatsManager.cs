using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    #region Statication

    public static StatsManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    #endregion

    [Header("Stream Stats")] 
    public int subscribers;
    public int viewers;
    //what is reputation lol
    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI subCount;
    [SerializeField] private TextMeshProUGUI viewerCount;

    public void UpdateSubscribers(int change)
    {
        subscribers += change;
        UpdateUI();
    }
    public void UpdateViewers(int change)
    {
        viewers += change;
        UpdateUI();
    }

    private void UpdateUI()
    {
        subCount.text = subscribers.ToString();
        viewerCount.text = viewers.ToString();
    }
}

