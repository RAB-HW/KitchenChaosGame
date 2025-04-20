using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    //要对DotText持有引用，好修改里面的点
   [SerializeField] private TextMeshProUGUI dotText;
    private float dotRate = 0.3f;

    private void Start()
    {
        //开启协程
        StartCoroutine(DotAnimation());
    }
    //使用携程的方式来进行播放
    IEnumerator DotAnimation()
    {
        while (true)
        {
            dotText.text = ".";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "..";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "...";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = ".....";
            yield return new WaitForSeconds(dotRate);
            dotText.text = "......";
            yield return new WaitForSeconds(dotRate);

        }

    }
}
