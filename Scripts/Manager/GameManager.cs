using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //创建单例模式，方便外界的获取
    public static GameManager Instance {  get; private set; }

    //提供一个事件，用来获取状态的改变
    public event EventHandler OnStateChanged;//每次状态改变都要调用这个方法

    
    private enum State//状态枚举
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver
    }

   [SerializeField] private Player player;//引用Player组件，为了禁止Player的移动
    private State state;//定义一个字段保存当前状态

    //不同状态下要有计时器，三个计时器
    private float waitingToStartTimer = 1;//开始的时间
    private float countDownToStartTimer = 3;//倒计时时间
    private float gamePlayingTimer = 30;//游戏时间
    void Awake()
    {
        Instance = this;

       
    }

    private void Start()
    {
        //初始状态
        TurnToWaitingToStart();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer-=Time.deltaTime;
                if(waitingToStartTimer <= 0)
                {
                    TurnToCountDownToStart();
                }
                break;
            case State.CountDownToStart:

                countDownToStartTimer-=Time.deltaTime;
                if(countDownToStartTimer <= 0)
                {
                    TurnToGamePlaying();
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer-=Time.deltaTime;
                if(gamePlayingTimer <= 0)
                {
                    TurnToGameOver();
                }
                break;
            case State.GameOver:
                break;
            default:
                break;
        }
    }

    //单独创建几个方法控制状态的转换

    private void TurnToWaitingToStart()
    {
        state=State.WaitingToStart;//在等待开始期间都是无法控制角色移动的
        DisablePlayer();
        OnStateChanged?.Invoke(this,EventArgs.Empty);
    }
    private void TurnToCountDownToStart()
    {
        state = State.CountDownToStart;
        DisablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);


    }

    private void TurnToGamePlaying()
    {
        state=State.GamePlaying;
        EnablePlayer();
        OnStateChanged?.Invoke(this, EventArgs.Empty);

    }

    private void TurnToGameOver()
    {
        state= State.GameOver;
        OnStateChanged?.Invoke(this, EventArgs.Empty);

    }

    //创建两个方法，用来控制Player的移动禁止和启用
    private void DisablePlayer()
    {
        player.enabled= false;
    }

    private void EnablePlayer()
    {
        player.enabled= true;
    }

    //提供一个方法，用来判断当前是否是倒计时状态，为了控制倒计时UI的显示
    public bool IsCountDownState()
    {
        return state==State.CountDownToStart;
    }

    //提供一个方法，判断游戏当前是否是游戏进行的状态
    public bool IsGamePlayingState()
    {
        return state== State.GamePlaying;
    }

    //提供一个方法，判断游戏当前是否是游戏结束的状态

    public bool IsGameOverState()
    {
        return state==State.GameOver;
    }

    //提供一个方法用来控制倒计时的时间
    public float GetCountDownTimer()
    {
        return countDownToStartTimer;
    }

    
}
