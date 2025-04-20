using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    //* 做一个限制，只有可以被煎的食材才能放到灶台上
    //当我们要把食材放到灶台里面的时候，要查看食谱，判断食材是否存在在食谱里面，如果存在，才可以放，不存在就不可以放
    [SerializeField] private FryingRecipeListSO fryingRecipeList;//通过拖拽的方式进行对食谱的引用
    [SerializeField] private FryingRecipeListSO burningRecipeList;//通过拖拽的方式进行对食谱的引用
    [SerializeField] private StoveCounterVisual stoveCounterVisual;//通过拖拽的方式进行对可视化的引用
    [SerializeField] private ProgressBarUI progressBarUI;//通过拖拽的方式进行对进度条的引用

    [SerializeField] private AudioSource Sound;//获取音效组件

    //通过一个枚举类型，表示煎锅的状态，有空闲和工作状态
    public enum StoveState
    {
        Idle,
        Frying,
        Burning,
    }

    //控制煎的操作
    private FryingRecipe fryingRecipe;//保存食谱
    private float fryingTimer = 0;
    private StoveState state = StoveState.Idle;//默认是一个生的状态

    public override void Interact(Player player)//用来交互
    {
        if (player.IsHaveKitchenObject())
        {
            //手上如果有食材
            if (IsHaveKitchenObject() == false)
                
            {
                if(fryingRecipeList.TryGetFryingRecipe(
                    player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe fryingRecipe))
                //第一个参数是手上的食材，第二个参数是对应的食谱，根据一个指定的食材去得到煎的食谱，
                //如果得到，就说明手上的食材存在于煎的食谱，表示可以煎，为true，就可以继续调用后面的方法
                //判断它是否可以煎
                {
                    //当前柜台没有食材，为空，可以转移
                    TransferKitchenObject(player, this);
                    StartFrying(fryingRecipe);//煎肉
                }
                else if(burningRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe burningRecipe))
                    //是否可以烧
                {
                    //当前柜台没有食材，为空，可以转移
                    TransferKitchenObject(player, this);
                    StartBurning(burningRecipe);//烧肉
                }
                else//不可以煎也不可以烧
                {

                }
                

            }
            else
            {
                //当前柜台有食材，不为空,转移到我们的手上
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
                TurnToIdle();

                TransferKitchenObject(this, player);
            }

        }
    }

    private void Update()
    {
        switch (state)
        {
            case StoveState.Idle://空闲状态下不需要做任何事情
                break;
            case StoveState.Frying:
                //让煎的时间增加
                fryingTimer += Time.deltaTime;
                //进行进度条的更新
                progressBarUI.UpdateProgress(fryingTimer/fryingRecipe.fryingTime);
                //判断煎的时间是否到达
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();//把当前食材销毁掉
                    //创建一个煎之后的食材
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    //state=StoveState.Burning;//这段代码不需要了
                    burningRecipeList.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(), 
                        out FryingRecipe newfryingRecipe);//判断在burningRecipeList里能否得到一个食谱，如果得到就开始烧
                    StartBurning(newfryingRecipe);

                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                //进行进度条的更新
                progressBarUI.UpdateProgress(fryingTimer / fryingRecipe.fryingTime);

                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();//把当前食材销毁掉
                    //创建一个煎之后的食材
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    TurnToIdle();
                    //煎完之后自动回到Idle状态
                }
                break;
            default:
                break;
        }
    }

    //定义一个方法，专门用来煎
    private void StartFrying(FryingRecipe fryingRecipe)
    {
        fryingTimer = 0;//保存煎的时间
        this.fryingRecipe = fryingRecipe;//保存煎的食谱
        //后面就可以在Update控制煎的时间操作了
        state = StoveState.Frying;//开始煎的时候，把状态修改为Frying
        stoveCounterVisual.ShowStoveEffect();//调用Show方法显示特效
        Sound.Play();//开始音效的播放
    }
    //定义一个方法，专门用来煎糊
    private void StartBurning(FryingRecipe fryingRecipe)
    {
        if(fryingRecipe == null)//安全校验
        {
            Debug.LogWarning("无法获得Burning的食谱，无法进行Burning");
            TurnToIdle();
            return;
        }
        stoveCounterVisual.ShowStoveEffect();//调用Show方法显示特效

        fryingTimer = 0;//保存煎的时间
        this.fryingRecipe = fryingRecipe;//保存煎的食谱
        state = StoveState.Burning;//开始煎的时候，把状态修改为Frying


    }
    //控制特效状态的转换
    private void TurnToIdle()
    {
        progressBarUI.Hide();//转换成Idle后隐藏进度条
        state=StoveState.Idle;
        stoveCounterVisual.HideStoveEffect();
        Sound.Pause();//暂停音效的播放
    }
}
