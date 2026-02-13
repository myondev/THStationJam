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
}

