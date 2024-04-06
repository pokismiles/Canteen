using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FridgeDoor : MonoBehaviour
{
    public bool isOpen = false;
    public bool isAnimating = false;

    public void DoorAction()
    {
        if (!isOpen && !isAnimating)
        {
            StartCoroutine(AnimateDoor("FridgeOpen"));
        }
        else if (isOpen && !isAnimating)
        {
            StartCoroutine(AnimateDoor("FridgeClose"));
        }
    }

    private IEnumerator AnimateDoor(string animationName)
    {
        isAnimating = true; // 设置动画播放标志为 true，防止其他动画播放

        // 播放动画
        this.GetComponent<Animator>().Play(animationName);

        // 等待动画播放完毕
        yield return new WaitForSeconds(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

        // 设置动画播放标志为 false，以允许下一次动画播放
        isAnimating = false;

        // 更新门的状态
        isOpen = !isOpen;
    }
}
