using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour//������ÿ��ʳ������
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;//ÿ��ʳ�Ķ����ж�����Ӧ���ݶ��������

    public KitchenObjectSO GetKitchenObjectSO()//ͨ����������Ϳ���ֱ�ӻ�ȡ���ʳ������Ӧ�����ݶ���
    {
        return kitchenObjectSO;
    }

}
