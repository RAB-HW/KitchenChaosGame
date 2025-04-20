using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]//加上特性可以通过右键创建
public class KitchenObjectSO : ScriptableObject
    //ScriptableObject的好处是可以直接在Unity中通过右键的方式创造一个对象，可以直接在本地进行实体化的保存
{
    public GameObject prefab;
    public Sprite sprite;//进行食物制作时，会出现菜单，有图标
    public string objectname;
}
