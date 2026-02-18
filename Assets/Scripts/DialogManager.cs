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
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private Image textBoxBg;
    [SerializeField] private float textSpeed;
    [SerializeField] private DialogScript dialogs;
    
    private bool dialogActive;

    public void LaunchDialog(string dialogId)
    {
        if (!dialogActive)
        { 
            textBox.gameObject.SetActive(true); 
            textBoxBg.gameObject.SetActive(true);
        }
        
        DialogData temp = dialogs.data.FirstOrDefault(x => x.dialogID == dialogId);
        dialogActive = true;
        StartCoroutine(ShowDialog(temp));
    }

    private IEnumerator ShowDialog(DialogData data)
    {
        textBox.text = "";
        
        //Remove one of the WaitForEndOfFrame, and it doesn't work well, dunno why :shrug:
        float textTimer = 0;
        int currentIndex = 0;
        yield return new WaitForEndOfFrame();
        while (textBox.text != data.text)
        {
            textTimer += Time.deltaTime;
            if (textTimer > textSpeed)
            {
                textBox.text += data.text[currentIndex];
                textTimer = 0;
                currentIndex++;
            }
            if(Mouse.current.leftButton.wasPressedThisFrame) textBox.text = data.text;
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => Mouse.current.leftButton.wasPressedThisFrame);
        yield return new WaitForEndOfFrame();
        if(data.nextDialogId != "") LaunchDialog(data.nextDialogId);
        else
        {
            dialogActive = false;
            textBox.gameObject.SetActive(false);
            textBoxBg.gameObject.SetActive(false);
        }
    }
}
