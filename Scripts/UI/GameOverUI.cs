using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    //Ϊ�˿���UIParent�������ʾ������,����Ҫ���ж�UIParent������
   [SerializeField] private GameObject uiParent;

    //Ҫ����Number������Ҫ���ж���������
    [SerializeField] private TextMeshProUGUI numberText;
    
    // Start is called before the first frame update
    void Start()
    {
        Hide();//�տ�ʼ�Ȱ�������
        //��ע��״̬�ı���¼�
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        //�жϵ�ǰ�Ƿ�����Ϸ������״̬
        if (GameManager.Instance.IsGameOverState())
        {
            Show();
        }
    }

   

    //�ṩ���غ���ʾ�ķ���
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
