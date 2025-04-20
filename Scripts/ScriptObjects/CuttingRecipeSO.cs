using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]//��CuttingRecipeSO���һ���������л�����
//[Serializable] ��һ���ǳ���Ҫ�� ���ԣ�Attribute���������ڱ��һ���ࡢ�ṹ����ֶο��Ա� ���л���Serialization��
public class CuttingRecipe
{
    public KitchenObjectSO input;//����ʳ��
    public KitchenObjectSO output;//���ʳ��
    public int cuttingCountMax;//��ʾ�߲���Ҫ�ж��ٵ������к�
}

[CreateAssetMenu()]//�������Ա�����

public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> list;

    //������ṩһ�����������õ�������Ӧ������������֪����̨Ӧ�÷�ʲôʳ��
    public KitchenObjectSO GetOutput(KitchenObjectSO input)
    {
        //����һ�¼��ϣ�Ȼ���ҳ���Ӧ�����������
        foreach (CuttingRecipe recipe in list)
        {
            if (recipe.input == input)//�������
            {
                return recipe.output;
            }

        }
        return null;//����������ˣ������Ҳ�����˵����ǰʳ�ﲻ��Ҫ��

    }
    //�ṩһ�����������Եõ��и�����ϵĵ���
    public bool TryGetCuttingRecipe(KitchenObjectSO input,out CuttingRecipe cuttingRecipe)
    {
        //����һ�¼��ϣ�Ȼ���ҳ���Ӧ�����������
        foreach (CuttingRecipe recipe in list)
        {
            if (recipe.input == input)//�������
            {
                cuttingRecipe = recipe;
                return true;
            }

        }
        cuttingRecipe = null;//û�õ�������Ϊnull
        return false;//����������ˣ������Ҳ�����˵����ǰʳ�ﲻ��Ҫ��
    }
}
