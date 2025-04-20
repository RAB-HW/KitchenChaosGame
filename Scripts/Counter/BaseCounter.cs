using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObejctHolder
    //把所有柜台拥有的共同功能放到里面，所有柜台都可以被选中，以及取消选择
{
    [SerializeField] private GameObject selectedCounter;//高亮，记得拖进去

    public virtual void Interact(Player player )//作为虚方法，方便子类重写
    {
        Debug.LogWarning("子类没有重写该方法");
    }

    public virtual void InteractOperate(Player player)//只有可以操作的柜台才能去重写这个方法
    {

    }

    //食材的传递功能

    public void SelectedCounter()
    {
        selectedCounter.SetActive(true);

    }

    public void CancelSelect()
    {
        selectedCounter.SetActive(false);
    }

    
}
