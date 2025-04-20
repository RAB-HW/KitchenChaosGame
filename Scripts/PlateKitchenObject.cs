using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    //��Ҫ��һ������ȥ��������ӵ�����ʳ��
    private List<KitchenObjectSO> kitchenObjectSOList=new List<KitchenObjectSO>();//�ٱȶԵ�ʱ��Ҫ�õ�

    //PlateCompletedVisual��������һ������
    [SerializeField] private PlateCompletedVisual plateCompletedVisual;

    //KitchenObjectGridUI��������һ������
    [SerializeField] private KitchenObjectGridUI kitchenObjectGridUI;

    //�ٶ���һ�����ϣ����浱ǰ���Խ��ܵ�ʳ��
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    //ʳ�ĵ����ݴ���
    public bool AddKitchenObjectSO(KitchenObjectSO kitchenObjectSO)//����ֵ�����Ƿ���ӳɹ�
    {
        //���֮ǰ�ж��Ƿ��Ѿ���ӹ���,�����Ƿ�������
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;   //��ӹ��Ļ������ʧ��
        }
        if(validKitchenObjectSOList.Contains(kitchenObjectSO)==false) 
        { 
            return false;
        }

        //ÿ��������������µ�ʳ�ĵ�ʱ�򣬾͵���һ��PlateCompletedVisual�ķ������ж�һ��ģ�ͣ�Ȼ���ģ�������ȥ
        plateCompletedVisual.ShowKitchenObject(kitchenObjectSO);
        //��ʾͼ��
        kitchenObjectGridUI.ShowKitchenObjectUI(kitchenObjectSO);
        kitchenObjectSOList.Add(kitchenObjectSO);//��ʳ�������ȥ
        return true;//��ӳɹ�
    }

    //�ṩһ��������������������׼���
    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
