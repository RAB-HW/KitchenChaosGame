using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image progressImage;//用来引用Image，通过拖拽方式
    public void Show()
    {
        gameObject.SetActive(true);//显示
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateProgress(float progress)//给外界提供一个方法用来设置进度，进度在0-1之间 用float
    {
        Show();//每次显示之前，调用Show显示，然后控制进度
        progressImage.fillAmount = progress;//用FillAmount属性设置为progress

        //切割完之后进行隐藏，隔一段时间隐藏
        if (progress == 1)
        {
            Invoke("Hide", 0.5f);//隔0.5s调用
        }
    }
}
