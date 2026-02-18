using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Dialog")]
    public class DialogScript :  ScriptableObject
    {
        public string dialogID;
        public List<DialogData> data;
    }
    [Serializable]
    public struct DialogData
    {
        public string text;
        public CharacterTalking characterTalking;
    }

public enum CharacterTalking {
    Hatate,
    Guest
}
