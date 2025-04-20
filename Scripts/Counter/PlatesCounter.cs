using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    //持有对盘子数据对象的引用，拖拽一下
    [SerializeField] private KitchenObjectSO plateSO;
    //要自动生成盘子，首先要有计时器
    [SerializeField] private float spawnRate = 2;//生成盘子的周期
    [SerializeField] private int plateCountMax = 5;//控制盘子生成的最大数量

    //生成的盘子要被放到一个集合里面保存
    private List<KitchenObject> platesList= new List<KitchenObject>();

    private float timer = 0;

    private void Update()
    {
        if(platesList.Count < plateCountMax)
        {
            timer += Time.deltaTime;
            //只有当盘子数量小于最大数量时，盘子才能增加，为了防止计时器一直增加，然后某一刻更改最大到达值后会立马生成

        }
        if (timer > spawnRate)
        {
            timer = 0;
            //传一个盘子的Prefab过来
            SpawnPlate();
        }
    }

    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject()==false)
        {
            //手上如果有食材，不能取盘子
            //手上如果没有食材，可以取盘子
            if (platesList.Count > 0)
            {
                player.AddKitchenObject(platesList[platesList.Count - 1]);//把集合里面最后一个盘子拿走
                platesList.RemoveAt(platesList.Count - 1);//移除最后一个
            }

        }
        
    }

    //创建新盘子的方法
    public void SpawnPlate()//用来根据指定的Prefab创造一个食材
    {
        if(platesList.Count>=plateCountMax)//如果盘子数量达到最大数量，停止生成
        {
            timer = 0;//当我们生成到最大数量时，把计时器归零，为了防止计时器一直增加，然后某一刻更改最大到达值后会立马生成
            return;
        }
        KitchenObject kitchenObject = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();//获取kitchenObject的组件

        //让每一个新生成的盘子都可以向上有一个位移
        kitchenObject.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * platesList.Count;//每新增一个盘子，就向上偏移0.1m

        //生成的盘子要放到集合里面
        platesList.Add(kitchenObject);


    }
}
