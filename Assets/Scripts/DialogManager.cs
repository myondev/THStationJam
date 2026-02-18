using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private float textSpeed;
    [SerializeField] private List<DialogScript> dialogs;
    [SerializeField] private GameObject guestDialog;
    [SerializeField] private GameObject hatateDialog;

    private bool dialogActive;
    private GameObject textBox;

    public bool IsDialogActive => dialogActive;

    public void LaunchDialog(string dialogId)
    {
        dialogActive = true;
        var temp = dialogs.FirstOrDefault(x => x.dialogID == dialogId);
        StartCoroutine(ShowDialog(temp));
    }

    private IEnumerator ShowDialog(DialogScript data)
    {
        foreach (var dialog in data.data)
        {
            textBox = dialog.characterTalking switch
            {
                CharacterTalking.Hatate => hatateDialog,
                CharacterTalking.Guest => guestDialog,
                _ => throw new ArgumentOutOfRangeException()
            };
            textBox.gameObject.SetActive(true);
            

            //Remove one of the WaitForEndOfFrame, and it doesn't work well, dunno why :shrug:
            float textTimer = 0;
            int currentIndex = 0;
            var text = textBox.GetComponentInChildren<TextMeshProUGUI>();
            yield return new WaitForEndOfFrame();
            while (text.text != dialog.text)
            {
                textTimer += Time.deltaTime;
                if (textTimer > textSpeed)
                {
                    text.text += dialog.text[currentIndex];
                    textTimer = 0;
                    currentIndex++;
                }

                if (Mouse.current.leftButton.wasPressedThisFrame) text.text = dialog.text;
                yield return null;
            }

            yield return new WaitForEndOfFrame();
            yield return new WaitUntil(() => Mouse.current.leftButton.wasPressedThisFrame);
            yield return new WaitForEndOfFrame();

            text.text = "";
            textBox.gameObject.SetActive(false);
        }
        dialogActive = false;
        CardManager.instance.canUseCards = true;
    }
}