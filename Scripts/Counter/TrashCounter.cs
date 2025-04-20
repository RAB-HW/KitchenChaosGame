using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnObjectTrashed;//�����¼�

    public override void Interact(Player player)
    {
        //��Ҫ���ǰ�Player���ϵĶ������ٵ�
        //�����ж�Player�����Ƿ��ж���
        if (player.IsHaveKitchenObject())
        {
            player.DestroyKitchenObject();//�еĻ����������ʳ��
            OnObjectTrashed?.Invoke(this,EventArgs.Empty);
        }
    }
}
