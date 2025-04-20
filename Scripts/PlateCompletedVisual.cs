using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompletedVisual : MonoBehaviour
{
    //要有一个模型跟数据对象的对应关系
    [Serializable]//可以序列化的
    public class KitchenObjectSO_Model
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject model;
    }

    [SerializeField] private List<KitchenObjectSO_Model> modelMap;

    //提供一个方法用来显示某个指定的食材
    public void ShowKitchenObject(KitchenObjectSO kitchenObjectSO)
    {
        foreach(KitchenObjectSO_Model item in modelMap)//找一下模型
        {
            if(item.kitchenObjectSO == kitchenObjectSO)//相等就是找到了
            {
                item.model.SetActive(true);//找到了就设为true，激活一下
                return;
            }
        }
    }
}
