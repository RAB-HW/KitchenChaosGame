using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    //为了控制UIParent整体的显示和隐藏,所以要持有对UIParent的引用
   [SerializeField] private GameObject uiParent;

    //要更新Number，首先要持有对它的引用
    [SerializeField] private TextMeshProUGUI numberText;
    
    // Start is called before the first frame update
    void Start()
    {
        Hide();//刚开始先把它隐藏
        //先注册状态改变的事件
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        //判断当前是否是游戏结束的状态
        if (GameManager.Instance.IsGameOverState())
        {
            Show();
        }
    }

   

    //提供隐藏和显示的方法
    private void Show()
    {
        numberText.text = OrderManager.Instance.GetSuccessDeliveryCount().ToString();
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
