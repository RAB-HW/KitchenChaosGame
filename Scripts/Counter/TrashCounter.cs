using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnObjectTrashed;//丢弃事件

    public override void Interact(Player player)
    {
        //主要就是把Player手上的东西销毁掉
        //首先判断Player手上是否有东西
        if (player.IsHaveKitchenObject())
        {
            player.DestroyKitchenObject();//有的话就销毁这个食材
            OnObjectTrashed?.Invoke(this,EventArgs.Empty);
        }
    }
}
