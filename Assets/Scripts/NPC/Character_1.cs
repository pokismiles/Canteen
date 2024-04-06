using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class Character_1 : MonoBehaviour
{
    public void StartConversation()
    {
        foreach (var trigger in this.GetComponents<DialogueSystemTrigger>())
        {
            trigger.OnUse();
        }
    }
}
