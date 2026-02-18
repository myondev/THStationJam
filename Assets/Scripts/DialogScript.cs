using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Dialog")]
    public class DialogScript :  ScriptableObject
    {
        public List<DialogData> data;
    }
    [Serializable]
    public struct DialogData
    {
        public string dialogID;
        public string text;
        public string nextDialogId;
    }
