using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    //创建一个事件，让其他地方注册
    public event EventHandler OnInteractAction;//交互事件触发时，就会触发这个事件
    public event EventHandler OnOperateAction;//监听Operate事件
    private GameControl gameControl;//保存创建好的gameControl，GameControl只是一个类
    private void Awake()
    {
        gameControl=new GameControl();//通过GameControl类去得到所有的事件
        gameControl.Player.Enable();//启用Player

        //当按下E键，就会触发这个方法
        gameControl.Player.Interact.performed += Interact_Performed;
        gameControl.Player.Operate.performed += Operate_Performed;

    }

    private void Operate_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this,EventArgs.Empty);
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);//先判断OnInteractAction是否为空，然后再执行后面的Invoke
    }

    public Vector3 GetMovementDirectionNormalized()
    {
        Vector2 inputVector2=gameControl.Player.Move.ReadValue<Vector2>();//得到二维向量的值
        //float horizontal = Input.GetAxisRaw("Horizontal");//左右，右x轴增加，左x轴减少
        //float vertical = Input.GetAxisRaw("Vertical");//上下，上z轴增加，下z轴减少
        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);//得到移动的方向

        //防止斜的移动朝向为根号二
        direction = direction.normalized;//单位化：把一个向量方向保持不变，大小变为1 1，0，1变成0.7，0，0.7

        return direction;
    }
}
