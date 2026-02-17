using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StreamingChatManager : MonoBehaviour
{
    [SerializeField] private StringList usernameList;
    [SerializeField] private StringList messageList;
    
    [SerializeField] private GameObject layout;
    [SerializeField] private GameObject chatMessagePrefab;
    [SerializeField] private float maximumBeforeMessage;
    [SerializeField] private float minimumBeforeMessage;
    [SerializeField] private int maximumMessages = 12;

    private float currentDelay;
    private float timeInSeconds;
    private float timer;
    private float messageSize;

    private void Start()
    {
        ChooseNewDelay();

        messageSize = layout.GetComponent<RectTransform>().rect.height / maximumMessages;
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
        string templateText = "streamtime username: text";

        float minutes = timeInSeconds / 60;
        templateText = templateText.Replace("streamtime", $"<color=#595959>{Mathf.Floor(timeInSeconds / 60f):00}:{(timeInSeconds % 60):00}</color>");
        
        Color randomColor = Random.ColorHSV();
        string hex = randomColor.ToHexString();
        templateText = templateText.Replace("username", $"<color=#{hex}>" + usernameList.stringList[Random.Range(0, usernameList.stringList.Count)] + "</color>");
        
        templateText = templateText.Replace("text",  messageList.stringList[Random.Range(0, messageList.stringList.Count)]);

        if (layout.transform.childCount > maximumMessages)
            Destroy(layout.transform.GetChild(0).gameObject);

        GameObject go =  Instantiate(chatMessagePrefab, layout.transform);
        var rectTransform = go.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, messageSize);
        var tmp = go.GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = templateText;
    }
}
