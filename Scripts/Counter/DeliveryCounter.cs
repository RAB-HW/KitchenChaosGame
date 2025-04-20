using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if(player.IsHaveKitchenObject()&&//�����ж���������Ƿ���ʳ��
            player.GetKitchenObject()//�ȵõ��������ϵ�ʳ��
            .TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject))
        //Ȼ�����TryGetComponent�������᷵��true��false��Ϊ���ж��Ƿ�õ�PlateKitchenObject���
        {
            //1.�ж��ϵĲ��Ƿ���ȷ
            OrderManager.Instance.DeliveryRecipe(plateKitchenObject);

            //2.������
            player.DestroyKitchenObject();
        }
    }
}
