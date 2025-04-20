using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI numberText;//���ж��������ı�������,number�ڸտ�ʼĬ�Ͻ���

    void Start()
    {
        //Ҫ��֪����Ϸ��״̬�͵���ʱ��ʱ��
        //����Ҫ�Ȼ�ȡGameManager
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    void Update()
    {
        //����number�ĸ��£�1��2��3
        if (GameManager.Instance.IsCountDownState())
        {
            numberText.text =Mathf.CeilToInt (GameManager.Instance.GetCountDownTimer()).ToString();
            //CeilToInt�������ؽӽ����������������2.1����3
        }
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        //ֻ�е�����ʱ״̬ʱ����ʾUI
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
