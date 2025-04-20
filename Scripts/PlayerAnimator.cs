using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";//申明一个常量，防止后面写错
    private Animator anim;//得到animator组件
    [SerializeField] private Player player;//为了获得player的iswalking属性，记得拖进去
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();//得到animator组件
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(IS_WALKING, player.IsWalking);//把这个属性设置到动画状态机里面
    }
}
