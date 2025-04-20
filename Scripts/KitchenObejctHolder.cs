using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//把有关食材转移和持有的功能全部放在这里面
public class KitchenObejctHolder : MonoBehaviour
{
    public static event EventHandler OnDrop;//放菜事件，只有放在Counter上才调用
    public static event EventHandler OnPickUp;//拿在手上事件，只有放在Counter上才调用


    [SerializeField] private Transform holdPoint;//引用topPoint
    private KitchenObject kitchenObject;
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public bool IsHaveKitchenObject()//判断是否有KitchenObject
    {
        return kitchenObject != null;
    }

    //提供一个可以得到食材数据对象的方法，免得每次都调用一大串
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObject.GetKitchenObjectSO();
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        if (this.kitchenObject != kitchenObject && kitchenObject != null & this is BaseCounter)
        //当前的食材不等于传递过来的食材（防止多次调用），传递过来的食材不等于null，当前的是一个柜台
        {
            OnDrop?.Invoke(this,EventArgs.Empty);
        }
        else if (this.kitchenObject != kitchenObject && kitchenObject != null & this is Player)
        {
            OnPickUp?.Invoke(this, EventArgs.Empty);

        }
        this.kitchenObject = kitchenObject;
        kitchenObject.transform.localPosition=Vector3.zero;
        
    }

    public Transform GetHoldPoint()
    {
        return holdPoint;
    }
    //判断原柜台的kitchenObejct是否存在，如果不在，肯定传输不了

    //完成桌子到桌子之间的传递
    public void TransferKitchenObject(KitchenObejctHolder sourceHolder, KitchenObejctHolder targetHolder)
    {
        if (sourceHolder.GetKitchenObject() == null)
        {
            Debug.LogWarning("原持有者上不存在食材，转移失败");
            return;
        }
        if (targetHolder.GetKitchenObject() != null)
        {
            Debug.LogWarning("目标持有者上存在食材，转移失败");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKitchenObject());
        sourceHolder.ClearKitchenObject();
    }
    //让目标柜台得到一个新的食材
    public void AddKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint);//把食材放进去
        SetKitchenObject(kitchenObject);
    }

    

    public void ClearKitchenObject()//清空原来柜台的食材
    {
        this.kitchenObject = null;
    }

    //用来销毁食材的方法
    public void DestroyKitchenObject()
    {
        Destroy(kitchenObject.gameObject);
        ClearKitchenObject();
    }

    //创建新食材的方法
    public void CreateKitchenObject(GameObject kitchenObjectPrefab)//用来根据指定的Prefab创造一个食材
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();//获取kitchenObject的组件
        SetKitchenObject(kitchenObject);//然后调用该方法把食材放到下面

    }
}
