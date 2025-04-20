using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���й�ʳ��ת�ƺͳ��еĹ���ȫ������������
public class KitchenObejctHolder : MonoBehaviour
{
    public static event EventHandler OnDrop;//�Ų��¼���ֻ�з���Counter�ϲŵ���
    public static event EventHandler OnPickUp;//���������¼���ֻ�з���Counter�ϲŵ���


    [SerializeField] private Transform holdPoint;//����topPoint
    private KitchenObject kitchenObject;
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public bool IsHaveKitchenObject()//�ж��Ƿ���KitchenObject
    {
        return kitchenObject != null;
    }

    //�ṩһ�����Եõ�ʳ�����ݶ���ķ��������ÿ�ζ�����һ��
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObject.GetKitchenObjectSO();
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        if (this.kitchenObject != kitchenObject && kitchenObject != null & this is BaseCounter)
        //��ǰ��ʳ�Ĳ����ڴ��ݹ�����ʳ�ģ���ֹ��ε��ã������ݹ�����ʳ�Ĳ�����null����ǰ����һ����̨
        {
            OnDrop?.Invoke(this,EventArgs.Empty);
        }
        else if (this.kitchenObject != kitchenObject && kitchenObject != null & this is Player)
        {
            OnPickUp?.Invoke(this, EventArgs.Empty);

        }
        this.kitchenObject = kitchenObject;
        kitchenObject.transform.localPosition=Vector3.zero;
        
    }

    public Transform GetHoldPoint()
    {
        return holdPoint;
    }
    //�ж�ԭ��̨��kitchenObejct�Ƿ���ڣ�������ڣ��϶����䲻��

    //������ӵ�����֮��Ĵ���
    public void TransferKitchenObject(KitchenObejctHolder sourceHolder, KitchenObejctHolder targetHolder)
    {
        if (sourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("ԭ�������ϲ�����ʳ�ģ�ת��ʧ��");
            return;
        }
        if (targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("Ŀ��������ϴ���ʳ�ģ�ת��ʧ��");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKitchenObject());
        sourceHolder.ClearKitchenObject();
    }
    //��Ŀ���̨�õ�һ���µ�ʳ��
    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint);//��ʳ�ķŽ�ȥ
        SetKitchenObject(kitchenObject);
    }

    

    public void ClearKitchenObject()//���ԭ����̨��ʳ��
    {
        this.kitchenObject = null;
    }

    //��������ʳ�ĵķ���
    public void DestroyKitchenObject()
    {
        Destroy(kitchenObject.gameObject);
        ClearKitchenObject();
    }

    //������ʳ�ĵķ���
    public void CreateKitchenObject(GameObject kitchenObjectPrefab)//��������ָ����Prefab����һ��ʳ��
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();//��ȡkitchenObject�����
        SetKitchenObject(kitchenObject);//Ȼ����ø÷�����ʳ�ķŵ�����

    }
}
