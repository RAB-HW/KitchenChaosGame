using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//仓库类柜台
public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;//拖进去食材预制体

    [SerializeField] private ContainerCounterVisual containerCounterVisual;//持有对子物体的引用
    //可以通过这种方式获取到，也可以通过拖拽方式获取
    //private void Start()
    //{
    //    containerCounterVisual = GetComponentInChildren;
    //}

    public override void Interact(Player player)
    {
        //ContainerCounter一直可以取得物品，只需要判断Player手上是否有物体就行
        if (player.IsHaveKitchenObject()) return;//如果主角身上已经持有食材，直接return，不必执行后面的代码
        CreateKitchenObject(kitchenObjectSO.prefab);//如果没有食材，从仓库去实例化一个食材
        TransferKitchenObject(this, player);//把这个食材从原位置传到Player身上
        containerCounterVisual.PlayerOpen();
    }

   
}
