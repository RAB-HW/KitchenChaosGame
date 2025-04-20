using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class CuttingCounter : BaseCounter
{
    public static event EventHandler OnCut;//��̬�¼������е�Counter����������¼�

    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;//�����и�ʳ��

    [SerializeField] private ProgressBarUI progressBarUI;//ͨ����ק���ж�ProgressBarUI������

    [SerializeField] private CuttingCounterVisual cuttingCounterVisual;//ͨ����ק���ж�CuttingCounterVisual������
    private int cuttingCount = 0;//��ʾ��ǰ�Ѿ����˶��ٵ�
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            //���������ʳ��
            if (IsHaveKitchenObject() == false)
            {
                cuttingCount = 0;//ÿ��һ���µ�ʳ����ȥ���Ͱѵ�������
                //��ǰ��̨û��ʳ�ģ�Ϊ�գ�����ת��
                TransferKitchenObject(player, this);

            }
            else
            {
                //��ǰ��̨��ʳ�ģ���Ϊ��,ת�Ƶ����ǵ�����
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
                //��ֹ�и���;�����߲ˣ���������Ȼ����ʾ
                progressBarUI.Hide();
            }

        }
    }

    public override void InteractOperate(Player player)//��д����
    {
        //�ѵ�ǰ�߲����٣�����һ���кõ��߲�
        if (IsHaveKitchenObject())//�жϵ�ǰ��̨�Ƿ���ʳ��
        {
            //���ݵ�ǰʳ�ĵõ����и���ʳ��
            //�ȵõ���ǰʳ�ģ�Ȼ��õ��������ݶ��󣬸������ݶ����ж��ܷ�õ�Output

            if (cuttingRecipeList.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO(), out CuttingRecipe cuttingRecipe))//Ȼ���ж��Ƿ�Ϊ�գ��Ƿ�����и�
                //��һ����������ʳ�ģ��ڶ������������и�ʳ���ϵĵ���
            {
                Cut();

                //ÿ���и��ʱ������������ı䣬����ProgressBarUI
                progressBarUI.UpdateProgress((float)cuttingCount/ cuttingRecipe.cuttingCountMax);//��ǰ�и���ȵ��ڵ�ǰ�и��/���и��

                if (cuttingCount == cuttingRecipe.cuttingCountMax)//�ж��еĵ����Ƿ��㹻
                {
                    DestroyKitchenObject();//����ʳ��
                    CreateKitchenObject(cuttingRecipe.output.prefab);//������Ӧ��ʳ��
                }
                
            }
            
        }
    }

    private void Cut()
    {
        OnCut?.Invoke(this, EventArgs.Empty);//�����¼�
        cuttingCount++;
        cuttingCounterVisual.PlayerCut();
    }
}
