using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObejctHolder
    //�����й�̨ӵ�еĹ�ͬ���ܷŵ����棬���й�̨�����Ա�ѡ�У��Լ�ȡ��ѡ��
{
    [SerializeField] private GameObject selectedCounter;//�������ǵ��Ͻ�ȥ

    public virtual void Interact(Player player )//��Ϊ�鷽��������������д
    {
        Debug.LogWarning("����û����д�÷���");
    }

    public virtual void InteractOperate(Player player)//ֻ�п��Բ����Ĺ�̨����ȥ��д�������
    {

    }

    //ʳ�ĵĴ��ݹ���

    public void SelectedCounter()
    {
        selectedCounter.SetActive(true);

    }

    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }

    
}
