using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //��������ģʽ���������Ļ�ȡ
    public static GameManager Instance {  get; private set; }

    //�ṩһ���¼���������ȡ״̬�ĸı�
    public event EventHandler OnStateChanged;//ÿ��״̬�ı䶼Ҫ�����������

    
    private enum State//״̬ö��
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver
    }

   [SerializeField] private Player player;//����Player�����Ϊ�˽�ֹPlayer���ƶ�
    private State state;//����һ���ֶα��浱ǰ״̬

    //��ͬ״̬��Ҫ�м�ʱ����������ʱ��
    private float waitingToStartTimer = 1;//��ʼ��ʱ��
    private float countDownToStartTimer = 3;//����ʱʱ��
    private float gamePlayingTimer = 30;//��Ϸʱ��
    void Awake()
    {
        Instance = this;

       
    }

    private void Start()
    {
        //��ʼ״̬
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

    //��������������������״̬��ת��

    private void TurnToWaitingToStart()
    {
        state=State.WaitingToStart;//�ڵȴ���ʼ�ڼ䶼���޷����ƽ�ɫ�ƶ���
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

    //����������������������Player���ƶ���ֹ������
    private void DisablePlayer()
    {
        player.enabled= false;
    }

    private void EnablePlayer()
    {
        player.enabled= true;
    }

    //�ṩһ�������������жϵ�ǰ�Ƿ��ǵ���ʱ״̬��Ϊ�˿��Ƶ���ʱUI����ʾ
    public bool IsCountDownState()
    {
        return state==State.CountDownToStart;
    }

    //�ṩһ���������ж���Ϸ��ǰ�Ƿ�����Ϸ���е�״̬
    public bool IsGamePlayingState()
    {
        return state== State.GamePlaying;
    }

    //�ṩһ���������ж���Ϸ��ǰ�Ƿ�����Ϸ������״̬

    public bool IsGameOverState()
    {
        return state==State.GameOver;
    }

    //�ṩһ�������������Ƶ���ʱ��ʱ��
    public float GetCountDownTimer()
    {
        return countDownToStartTimer;
    }

    
}
