using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompletedVisual : MonoBehaviour
{
    //Ҫ��һ��ģ�͸����ݶ���Ķ�Ӧ��ϵ
    [Serializable]//�������л���
    public class KitchenObjectSO_Model
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject model;
    }

    [SerializeField] private List<KitchenObjectSO_Model> modelMap;

    //�ṩһ������������ʾĳ��ָ����ʳ��
    public void ShowKitchenObject(KitchenObjectSO kitchenObjectSO)
    {
        foreach(KitchenObjectSO_Model item in modelMap)//��һ��ģ��
        {
            if(item.kitchenObjectSO == kitchenObjectSO)//��Ⱦ����ҵ���
            {
                item.model.SetActive(true);//�ҵ��˾���Ϊtrue������һ��
                return;
            }
        }
    }
}
