using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class  DayManager : MonoBehaviour
{
    [SerializeField] private List<Day> dayList;
    [Header("Black Screen")]
    [SerializeField] private Image blackScreen;
    [SerializeField] private float blackScreenFadeIn;
    [SerializeField] private float blackScreenFadeOut;
    [Header("Refs")]
    [SerializeField] private Image guestImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private StreamingChatManager streamingChatManager;
    
    public static DayManager instance;
    private int currentDay = 0;

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private IEnumerator Start()
    {
        streamingChatManager.IsWorking = false;
        ChangeDay();

        float count = 0;
        while (count < blackScreenFadeOut)
        {
            float currentAlpha = Mathf.Lerp(1, 0, count /  blackScreenFadeOut);
            blackScreen.color = Color.black * currentAlpha;
            count += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        blackScreen.gameObject.SetActive(false);
        streamingChatManager.IsWorking = true;
        CardManager.instance.GenerateCardUI();
    }

    public IEnumerator EndDay()
    {
        //To call when all cards have been used
        currentDay++;
        
        //Show stats of the day
        yield return new WaitUntil(() => Mouse.current.leftButton.isPressed);
        //Hide stats

        blackScreen.gameObject.SetActive(true);
        float count = 0;
        while (count < blackScreenFadeIn)
        {
            float currentAlpha = Mathf.Lerp(0, 1, count /  blackScreenFadeIn);
            blackScreen.color = Color.black * currentAlpha;
            count += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        StartCoroutine(Start());
    }

    private void ChangeDay()
    {
        guestImage.sprite = dayList[currentDay].guest;
        backgroundImage.sprite = dayList[currentDay].background;
        
        audioSource.Stop();
        audioSource.clip = dayList[currentDay].clip;
        audioSource.Play();
        
        streamingChatManager.ResetChat();
        CardManager.instance.GenerateCardUI();
    }

    [Serializable]
    public struct Day
    {
        public Sprite guest;
        public Sprite background;
        public AudioClip clip;
    }
}
