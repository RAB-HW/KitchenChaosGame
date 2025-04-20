using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance {  get; private set; }//为了在DeliveryCounter那里调用，把他制作成单例模式

    //这个事件是当我们下了一个订单的时候就会触发
    public event EventHandler OnRecipeSpawned;

    //这个事件是当我们完成一个订单的时候就会触发、
    public event EventHandler OnRecipeSuccessed;

    //这个事件是当我们没有成功完成一个订单的时候就会触发、
    public event EventHandler OnRecipeFailed;

    [SerializeField] private RecipeListSO recipeSOList;//引用菜单
    //下单周期
    [SerializeField] private float orderRate = 2;

    //限制最大下单单数
   [SerializeField] private int orderMaxCount = 5;

    //保存当前顾客下的单，保存所有的食谱
    private List<RecipeSO> orderRecipeSOlist = new List<RecipeSO>();
    //计时器计时
    private float orderTimer = 0;

    //标志位，表示是否开始下单/营业
    private bool isStartOrder = false;

    private int orderCount = 0;//目前已经下单单数，默认为零，每次下单之后增加

    private int successDeliveryCount = 0;//成功运输的数量

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;//注册事件
    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        //判断当前状态是否是游戏状态
        if(GameManager.Instance.IsGamePlayingState())//如果是就开始下单
        {
            StartSpawnOrder();//调用下单开始方法
        }
    }

    private void Update()
    {
        if (isStartOrder)
        {
            OrderUpdate();
        }
    }

    //订单更新
    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;
        if(orderTimer >=orderRate)
        {
            orderTimer = 0;
            OrderANewRecipe();//下单
        }


    }

    private void OrderANewRecipe()
    {
        if (orderCount >= orderMaxCount)//达到最大下单单数就停止下单
        {
            return;
        }
        orderCount++;
        int index=UnityEngine.Random.Range(0, recipeSOList.recipeSOList.Count);//生成一个随机数，就是集合recipeSOList里面的随机索引
        orderRecipeSOlist.Add(recipeSOList.recipeSOList[index]);//给菜谱添加食材

        //生成一个事件去进行触发
        OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
    }

    //提供一个方法，进行上菜和下单的对比,要在DeliveryCounter.cs调用
    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)//为什么传的是盘子，是因为盘子上保存着所有食材的集合列表，用来判断
    {
        RecipeSO correctionRecipe = null;//正确菜谱
        //要遍历顾客下的单和实际上的菜的菜谱是否是一致的
        foreach(RecipeSO recipe in orderRecipeSOlist)
        {
            if(IsCorrect(recipe, plateKitchenObject))//如果返回true
            {
                correctionRecipe=recipe; //就是正确菜谱
                break;

            }
                
        }
        if(correctionRecipe == null)
        {
            print("上菜失败");
            OnRecipeFailed?.Invoke(this, EventArgs.Empty);

        }
        else
        {
            orderRecipeSOlist.Remove(correctionRecipe);//如果上菜成功，就把它从顾客的菜谱上去掉
            OnRecipeSuccessed?.Invoke(this, EventArgs.Empty);
            successDeliveryCount++;//当上菜成功要让传输成功的数量增加
            print("上菜成功");
        }
    }

    //提供一个比对的方法

    private bool IsCorrect(RecipeSO recipeSO,PlateKitchenObject plateKitchenObject)//第一个参数是顾客下的单，第二个参数是我们实际做的菜
    {
        //要比对两个集合
        List<KitchenObjectSO>list=recipeSO.kitchenObjectSOList;
        List<KitchenObjectSO>list2=plateKitchenObject.GetKitchenObjectSOList();

        //首先对比长度
        if (list.Count != list.Count)
        {
            return false;
        }

        //遍历一个集合，观察是否包含另外一个集合的所有元素
        foreach(KitchenObjectSO kitchenObjectSO in list)
        {
            if (list2.Contains(kitchenObjectSO)==false)//如果有不包含的就说明不一样
            {
                return false;
            }
        }
        return true;
    }

    //提供一个获取订单集合的方法
    public List<RecipeSO> GetOrderList()
    {
        return orderRecipeSOlist;
    }

    //提供一个方法用于开始生成订单
    public void StartSpawnOrder()
    {
        isStartOrder = true;
    }

    //提供一个方法让外界可以获得successDeliveryCount
    public int GetSuccessDeliveryCount()
    {
        return successDeliveryCount;
    }
}
