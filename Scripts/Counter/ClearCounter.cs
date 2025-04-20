using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    
    public override void Interact(Player player)
    {
        if(player.IsHaveKitchenObject())
        {
            ////手上如果有食材
            

            //手上如果有食材

            //如果手上是盘子，就把柜台上的食材放到盘子里
            if(player.GetKitchenObject().TryGetComponent<PlateKitchenObject>(out PlateKitchenObject platekitchenObject))
            {
                if (IsHaveKitchenObject() == false)
                {
                    //当前柜台没有食材，为空，可以转移
                    TransferKitchenObject(player, this);

                }
                else
                {
                    //当前柜台有食材，不为空,转移到我们的盘子上
                    //TODD
                    //食材的显示部分
                    bool isSuccess= platekitchenObject.AddKitchenObjectSO(GetKitchenObjectSO());//转移到我们的盘子上,bool存放是否添加成功
                    if (isSuccess)
                    {
                        DestroyKitchenObject();//销毁当前桌子上的食材

                    }
                }
            }
            else
            {
                //手上是普通的食材
                if (IsHaveKitchenObject() == false)
                {
                    //当前柜台没有食材，为空，可以转移
                    TransferKitchenObject(player, this);

                }
                else
                {
                    //当前柜台有盘子，不为空,就把手上的食材放到柜台上的盘子
                    if(GetKitchenObject().TryGetComponent<PlateKitchenObject>(out platekitchenObject))//如果柜台上的东西是盘子
                    {
                        //就把手上的食材放到柜台上的盘子
                        if (platekitchenObject.AddKitchenObjectSO(player.GetKitchenObjectSO()))//如果添加成功
                        {
                            player.DestroyKitchenObject();//销毁
                        }
                    }
                }
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
            }

        }
    }

    
    
}
