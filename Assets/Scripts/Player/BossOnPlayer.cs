using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using PixelCrushers.DialogueSystem;

public class BossOnPlayer : MonoBehaviour
{
    public TeleportPlayerFade teleport;
    public ScreenFader screenFader;
    public Transform bossTalkPosition;
    public GameObject boss;

    public void talkToBoss()
    {
        teleport.ResetPlayerPosRotWithParameters(bossTalkPosition, screenFader);

        StartCoroutine(endConversationAndTeleport());
    }

    public void talkToBossAgain()
    {
        QuestLog.SetQuestState("Boss_Second", QuestState.Success);

        teleport.ResetPlayerPosRotWithParameters(bossTalkPosition, screenFader);

        StartCoroutine(endConversationAndTeleport());
    }

    private IEnumerator endConversationAndTeleport()
    {
        yield return new WaitForSeconds(0.5f);
        //talk
        foreach (var item in boss.GetComponents<DialogueSystemTrigger>())
        {
            item.OnUse();
        }
    }
}
