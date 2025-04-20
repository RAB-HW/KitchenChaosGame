using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ֿ����̨
public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;//�Ͻ�ȥʳ��Ԥ����

    [SerializeField] private ContainerCounterVisual containerCounterVisual;//���ж������������
    //����ͨ�����ַ�ʽ��ȡ����Ҳ����ͨ����ק��ʽ��ȡ
    //private void Start()
    //{
    //    containerCounterVisual = GetComponentInChildren;
    //}

    public override void Interact(Player player)
    {
        //ContainerCounterһֱ����ȡ����Ʒ��ֻ��Ҫ�ж�Player�����Ƿ����������
        if (player.IsHaveKitchenObject()) return;//������������Ѿ�����ʳ�ģ�ֱ��return������ִ�к���Ĵ���
        CreateKitchenObject(kitchenObjectSO.prefab);//���û��ʳ�ģ��Ӳֿ�ȥʵ����һ��ʳ��
        TransferKitchenObject(this, player);//�����ʳ�Ĵ�ԭλ�ô���Player����
        containerCounterVisual.PlayerOpen();
    }

   
}
