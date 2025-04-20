using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI numberText;//持有对子物体文本的引用,number在刚开始默认禁用

    void Start()
    {
        //要先知道游戏的状态和倒计时的时间
        //所以要先获取GameManager
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    void Update()
    {
        //控制number的更新，1，2，3
        if (GameManager.Instance.IsCountDownState())
        {
            numberText.text =Mathf.CeilToInt (GameManager.Instance.GetCountDownTimer()).ToString();
            //CeilToInt用来返回接近的最大整数，例如2.1返回3
        }
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        //只有当倒计时状态时才显示UI
        if(GameManager.Instance.IsCountDownState())
        {
            numberText.gameObject.SetActive(true);
        }
        else
        {
           numberText.gameObject.SetActive(false);
        }
    }

   
}
