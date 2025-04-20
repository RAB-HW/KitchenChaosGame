using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator anim;//持有组件
    // Start is called before the first frame update
    void Start()
    {
        //得到组件
        anim = GetComponent<Animator>();
        
    }

    //对外提供一个方法，用来播放动画
    public void PlayerOpen()
    {
        anim.SetTrigger("OpenClose");
    }
}
