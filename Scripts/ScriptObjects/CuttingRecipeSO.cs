using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]//让CuttingRecipeSO变成一个可以序列化的类
//[Serializable] 是一个非常重要的 特性（Attribute），它用于标记一个类、结构体或字段可以被 序列化（Serialization）
public class CuttingRecipe
{
    public KitchenObjectSO input;//输入食材
    public KitchenObjectSO output;//输出食材
    public int cuttingCountMax;//表示蔬菜需要切多少刀才能切好
}

[CreateAssetMenu()]//让他可以被创建

public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> list;

    //给外界提供一个方法用来得到输入相应的输出，让外界知道柜台应该放什么食材
    public KitchenObjectSO GetOutput(KitchenObjectSO input)
    {
        //遍历一下集合，然后找出相应的输出就行了
        foreach (CuttingRecipe recipe in list)
        {
            if (recipe.input == input)//输入相等
            {
                return recipe.output;
            }

        }
        return null;//如果遍历完了，还是找不到，说明当前食物不需要切

    }
    //提供一个方法，可以得到切割菜谱上的刀数
    public bool TryGetCuttingRecipe(KitchenObjectSO input,out CuttingRecipe cuttingRecipe)
    {
        //遍历一下集合，然后找出相应的输出就行了
        foreach (CuttingRecipe recipe in list)
        {
            if (recipe.input == input)//输入相等
            {
                cuttingRecipe = recipe;
                return true;
            }

        }
        cuttingRecipe = null;//没得到就设置为null
        return false;//如果遍历完了，还是找不到，说明当前食物不需要切
    }
}
