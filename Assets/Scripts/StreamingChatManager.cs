using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StreamingChatManager : MonoBehaviour
{
    [SerializeField] private GameObject layout;
    [SerializeField] private GameObject chatMessagePrefab;
    [SerializeField] private float maximumBeforeMessage;
    [SerializeField] private float minimumBeforeMessage;

    private float currentDelay;
    private float timeInSeconds;
    private float timer;

    private void Start()
    {
        ChooseNewDelay();
    }

    private void Update()
    {
        timeInSeconds += Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= currentDelay)
        {
            ChooseNewDelay();
            timer = 0;
            
            CraftMessage();
        }
    }

    private void ChooseNewDelay()
    {
        currentDelay = Random.Range(minimumBeforeMessage, maximumBeforeMessage);
    }

    private void CraftMessage()
    {
        GameObject go =  Instantiate(chatMessagePrefab, layout.transform);
        var tmp = go.GetComponentInChildren<TextMeshProUGUI>();
        string templateText = "streamtime username: text";
        templateText = templateText.Replace("streamtime", "<color=#595959>" + timeInSeconds.ToString("0:00") + "</color>");
        
        Color randomColor = Random.ColorHSV();
        string hex = randomColor.ToHexString();
        templateText = templateText.Replace("username", $"<color=#{hex}>" + "ItsAMe" + "</color>");
        
        templateText = templateText.Replace("text",  "Just wanna say I love you");
        
        tmp.text = templateText;
    }
}
