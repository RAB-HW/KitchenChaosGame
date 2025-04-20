using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";//����һ����������ֹ����д��
    private Animator anim;//�õ�animator���
    [SerializeField] private Player player;//Ϊ�˻��player��iswalking���ԣ��ǵ��Ͻ�ȥ
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();//�õ�animator���
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(IS_WALKING, player.IsWalking);//������������õ�����״̬������
    }
}
