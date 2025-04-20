using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FryingRecipeListSO : ScriptableObject//��ŵ���ʳ�׵ļ���
{
    public List<FryingRecipe> list;

    //�ṩһ��get���������������Ҳ���Ի��һ��ʳ��,������֮���Ӧ��ʳ��ͼ��ʱ��
    public bool TryGetFryingRecipe(KitchenObjectSO input, out FryingRecipe fryingRecipe)
    {
        //����һ�¼��ϣ�Ȼ���ҳ���Ӧ�����������
        foreach (FryingRecipe recipe in list)
        {
            if (recipe.input == input)//�������
            {
                fryingRecipe = recipe;
                return true;
            }

        }
        fryingRecipe = null;//û�õ�������Ϊnull
        return false;//����������ˣ������Ҳ�����˵����ǰʳ�ﲻ��Ҫ��
    }
}

//��ŵ��ǵ���ʳ�Ķ�Ӧ��ʳ��
[Serializable]
public class FryingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float fryingTime;
}
