using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class CuttingCounter : BaseCounter
{
    public static event EventHandler OnCut;//静态事件，所有的Counter都会有这个事件

    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;//引用切割食物

    [SerializeField] private ProgressBarUI progressBarUI;//通过拖拽持有对ProgressBarUI的引用

    [SerializeField] private CuttingCounterVisual cuttingCounterVisual;//通过拖拽持有对CuttingCounterVisual的引用
    private int cuttingCount = 0;//表示当前已经切了多少刀
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            //手上如果有食材
            if (IsHaveKitchenObject() == false)
            {
                cuttingCount = 0;//每放一个新的食材上去，就把刀数归零
                //当前柜台没有食材，为空，可以转移
                TransferKitchenObject(player, this);

            }
            else
            {
                //当前柜台有食材，不为空,转移到我们的手上
            }
        }
        else
        {
            //手上如果没有食材
            if (IsHaveKitchenObject() == false)
            {
                //当前柜台没有食材，为空，可以转移
            }
            else
            {
                //当前柜台有食材，不为空,转移到我们的手上
                TransferKitchenObject(this, player);
                //防止切割中途拿走蔬菜，进度条仍然在显示
                progressBarUI.Hide();
            }

        }
    }

    public override void InteractOperate(Player player)//重写方法
    {
        //把当前蔬菜销毁，创建一个切好的蔬菜
        if (IsHaveKitchenObject())//判断当前柜台是否有食材
        {
            //根据当前食材得到它切割后的食材
            //先得到当前食材，然后得到它的数据对象，根据数据对象判断能否得到Output

            if (cuttingRecipeList.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO(), out CuttingRecipe cuttingRecipe))//然后判断是否为空，是否可以切割
                //第一个参数返回食材，第二个参数返回切割食谱上的刀数
            {
                Cut();

                //每次切割的时候进度条发生改变，调用ProgressBarUI
                progressBarUI.UpdateProgress((float)cuttingCount/ cuttingRecipe.cuttingCountMax);//当前切割进度等于当前切割刀数/总切割刀数

                if (cuttingCount == cuttingRecipe.cuttingCountMax)//判断切的刀数是否足够
                {
                    DestroyKitchenObject();//销毁食材
                    CreateKitchenObject(cuttingRecipe.output.prefab);//创建对应的食材
                }
                
            }
            
        }
    }

    private void Cut()
    {
        OnCut?.Invoke(this, EventArgs.Empty);//触发事件
        cuttingCount++;
        cuttingCounterVisual.PlayerCut();
    }
}
