using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FryingRecipeListSO : ScriptableObject//存放的是食谱的集合
{
    public List<FryingRecipe> list;

    //提供一个get方法，让她在外界也可以获得一个食谱,包括煎之后对应的食物和煎的时间
    public bool TryGetFryingRecipe(KitchenObjectSO input, out FryingRecipe fryingRecipe)
    {
        //遍历一下集合，然后找出相应的输出就行了
        foreach (FryingRecipe recipe in list)
        {
            if (recipe.input == input)//输入相等
            {
                fryingRecipe = recipe;
                return true;
            }

        }
        fryingRecipe = null;//没得到就设置为null
        return false;//如果遍历完了，还是找不到，说明当前食物不需要切
    }
}

//存放的是单个食材对应的食谱
[Serializable]
public class FryingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float fryingTime;
}
