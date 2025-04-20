using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectGridUI : MonoBehaviour
{
    [SerializeField] private KitchenObjectIconUI iconTemplateUI;//ͨ����ק��iconTemplateUI��������

    //Ĭ�ϵ�һ��ģ��iconTemplateUI����Ϊģ��ģ�������ʾ��������������ͼ���
   
    private void Start()
    {
        iconTemplateUI.Hide();
        //iconTemplateUI.gameObject.SetActive(false);
    }
    public void ShowKitchenObjectUI(KitchenObjectSO kitchenObjectSO)
    {
        //������Ҫָ��һ��ͼ���ʱ��ͨ��IconTemplateʵ����һ���µ�
       KitchenObjectIconUI newIconUI= GameObject.Instantiate(iconTemplateUI,transform);//�µ�ͼ��Ҫ�ŵ������·�

        //newIconUI.transform.SetParent(transform);������ĵڶ�������Ч��һ��
        newIconUI.Show(kitchenObjectSO.sprite);
    }
}
