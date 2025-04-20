using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    //需要有一个集合去保存已添加的所有食材
    private List<KitchenObjectSO> kitchenObjectSOList=new List<KitchenObjectSO>();//再比对的时候要用的

    //PlateCompletedVisual对它持有一个引用
    [SerializeField] private PlateCompletedVisual plateCompletedVisual;

    //KitchenObjectGridUI对它持有一个引用
    [SerializeField] private KitchenObjectGridUI kitchenObjectGridUI;

    //再定义一个集合，保存当前可以接受的食材
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    //食材的数据处理：
    public bool AddKitchenObjectSO(KitchenObjectSO kitchenObjectSO)//返回值代表是否添加成功
    {
        //添加之前判断是否已经添加过了,还有是否可以添加
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;   //添加过的话就添加失败
        }
        if(validKitchenObjectSOList.Contains(kitchenObjectSO)==false) 
        { 
            return false;
        }

        //每次往盘子上添加新的食材的时候，就调用一下PlateCompletedVisual的方法，判断一下模型，然后把模型添加上去
        plateCompletedVisual.ShowKitchenObject(kitchenObjectSO);
        //显示图标
        kitchenObjectGridUI.ShowKitchenObjectUI(kitchenObjectSO);
        kitchenObjectSOList.Add(kitchenObjectSO);//把食材添加上去
        return true;//添加成功
    }

    //提供一个方法用来拿走这个菜谱集合
    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
