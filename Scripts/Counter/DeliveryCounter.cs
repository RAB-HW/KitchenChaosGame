using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if(player.IsHaveKitchenObject()&&//首先判断玩家手上是否有食材
            player.GetKitchenObject()//先得到主角身上的食材
            .TryGetComponent<PlateKitchenObject>(out PlateKitchenObject plateKitchenObject))
        //然后调用TryGetComponent方法，会返回true和false，为了判断是否得到PlateKitchenObject组件
        {
            //1.判断上的菜是否正确
            OrderManager.Instance.DeliveryRecipe(plateKitchenObject);

            //2.销毁它
            player.DestroyKitchenObject();
        }
    }
}
