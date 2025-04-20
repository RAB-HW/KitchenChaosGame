using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour//挂在了每个食材身上
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;//每个食材都持有对所对应数据对象的引用

    public KitchenObjectSO GetKitchenObjectSO()//通过这个方法就可以直接获取这个食材所对应的数据对象
    {
        return kitchenObjectSO;
    }

}
