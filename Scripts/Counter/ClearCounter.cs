using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    
    public override void Interact(Player player)
    {
        if(player.IsHaveKitchenObject())
        {
            ////���������ʳ��
            

            //���������ʳ��

            //������������ӣ��Ͱѹ�̨�ϵ�ʳ�ķŵ�������
            if(player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject platekitchenObject))
            {
                if (IsHaveKitchenObject() == false)
                {
                    //��ǰ��̨û��ʳ�ģ�Ϊ�գ�����ת��
                    TransferKitchenObject(player, this);

                }
                else
                {
                    //��ǰ��̨��ʳ�ģ���Ϊ��,ת�Ƶ����ǵ�������
                    //TODD
                    //ʳ�ĵ���ʾ����
                    bool isSuccess= platekitchenObject.AddKitchenObjectSO(GetKitchenObjectSO());//ת�Ƶ����ǵ�������,bool����Ƿ���ӳɹ�
                    if (isSuccess)
                    {
                        DestroyKitchenObject();//���ٵ�ǰ�����ϵ�ʳ��

                    }
                }
            }
            else
            {
                //��������ͨ��ʳ��
                if (IsHaveKitchenObject() == false)
                {
                    //��ǰ��̨û��ʳ�ģ�Ϊ�գ�����ת��
                    TransferKitchenObject(player, this);

                }
                else
                {
                    //��ǰ��̨�����ӣ���Ϊ��,�Ͱ����ϵ�ʳ�ķŵ���̨�ϵ�����
                    if(GetKitchenObject().TryGetComponent<PlateKitchenObject>(out platekitchenObject))//�����̨�ϵĶ���������
                    {
                        //�Ͱ����ϵ�ʳ�ķŵ���̨�ϵ�����
                        if (platekitchenObject.AddKitchenObjectSO(player.GetKitchenObjectSO()))//�����ӳɹ�
                        {
                            player.DestroyKitchenObject();//����
                        }
                    }
                }
            }

        }
        else
        {
            //�������û��ʳ��
            if (IsHaveKitchenObject() == false)
            {
                //��ǰ��̨û��ʳ�ģ�Ϊ�գ�����ת��
            }
            else
            {
                //��ǰ��̨��ʳ�ģ���Ϊ��,ת�Ƶ����ǵ�����
                TransferKitchenObject(this, player);
            }

        }
    }

    
    
}
