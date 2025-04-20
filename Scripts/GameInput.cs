using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    //����һ���¼����������ط�ע��
    public event EventHandler OnInteractAction;//�����¼�����ʱ���ͻᴥ������¼�
    public event EventHandler OnOperateAction;//����Operate�¼�
    private GameControl gameControl;//���洴���õ�gameControl��GameControlֻ��һ����
    private void Awake()
    {
        gameControl=new GameControl();//ͨ��GameControl��ȥ�õ����е��¼�
        gameControl.Player.Enable();//����Player

        //������E�����ͻᴥ���������
        gameControl.Player.Interact.performed += Interact_Performed;
        gameControl.Player.Operate.performed += Operate_Performed;

    }

    private void Operate_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this,EventArgs.Empty);
    }

    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);//���ж�OnInteractAction�Ƿ�Ϊ�գ�Ȼ����ִ�к����Invoke
    }

    public Vector3 GetMovementDirectionNormalized()
    {
        Vector2 inputVector2=gameControl.Player.Move.ReadValue<Vector2>();//�õ���ά������ֵ
        //float horizontal = Input.GetAxisRaw("Horizontal");//���ң���x�����ӣ���x�����
        //float vertical = Input.GetAxisRaw("Vertical");//���£���z�����ӣ���z�����
        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);//�õ��ƶ��ķ���

        //��ֹб���ƶ�����Ϊ���Ŷ�
        direction = direction.normalized;//��λ������һ���������򱣳ֲ��䣬��С��Ϊ1 1��0��1���0.7��0��0.7

        return direction;
    }
}
